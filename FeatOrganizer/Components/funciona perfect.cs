/*using System;
using System.Linq;
using System.Reflection;
using FeatOrganizer.Utils; // Log
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Recommendations;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Class.LevelUp;
using UnityEngine;

namespace FeatOrganizer.Components
{
    /// Recomienda la carpeta si (y solo si) tiene ≥1 hijo visible, elegible AHORA y recomendado por el core.
    [Serializable]
    public class AggregateMemberRecommendations : LevelUpRecommendationComponent
    {
        private const string LOG = "[FO][AggRec] ";

        private static void Trace(string msg)
        {
#if DEBUG
            Log.DebugLog(LOG + msg);
#else
            Log.Info(LOG + msg);
#endif
        }

        public BlueprintFeatureReference[] Members = Array.Empty<BlueprintFeatureReference>();

        public override RecommendationPriority GetPriority(LevelUpState state)
        {
            if (state?.Unit == null || Members == null || Members.Length == 0)
                return RecommendationPriority.Same;

            var unit = state.Unit;

            // 1) Dueña (si la hay)
            var ownerBp = GetOwnerBlueprint(this) as BlueprintFeatureSelection;

            // 2) Selección visible/actual (fallback)
            var evalSelState = (ownerBp != null)
                ? state.Selections.FirstOrDefault(s => ReferenceEquals(s.Selection, ownerBp))
                : state.Selections.LastOrDefault();

            Trace($"Folder={(ownerBp != null ? ownerBp.name : "(null)")}  EvalSel={SelName(evalSelState)}  Selections={state.Selections.Count}");

            foreach (var m in Members)
            {
                var feat = m?.Get();
                if (feat?.ComponentsArray == null) continue;

                if (unit.HasFact(feat))
                {
                    Trace($"skip {feat.name}: already known");
                    continue;
                }

                if (IsHiddenInUI(feat))
                {
                    Trace($"skip {feat.name}: hidden-in-ui");
                    continue;
                }

                // Pool (robusto por grupos; si no se puede determinar, no bloqueamos)
                if (!IsInSelectionPool(evalSelState, feat))
                {
                    Trace($"skip {feat.name}: not in pool of {SelName(evalSelState)}");
                    continue;
                }

                // Prerrequisitos igual que la UI
                var prereqOk = MeetsPrereqsNative(feat, unit, state, evalSelState);
                if (!prereqOk)
                {
                    Trace($"skip {feat.name}: prereqs fail (sel={SelName(evalSelState)})");
                    continue;
                }

                // Recomendación “core” (del juego)
                int core = 0;
                try { core = LevelUpRecommendationEx.GetRecommendationPriority(feat, state); }
                catch (Exception ex)
                {
                    Trace($"core-rec ex for {feat.name}: {ex.GetType().Name} {ex.Message}");
                }

                if (core > 0)
                {
                    Trace($"GOOD -> Folder={(ownerBp != null ? ownerBp.name : "(null)")}  Feat={feat.name}  Core={core}  Sel={SelName(evalSelState)}  PrereqOK={prereqOk}");
                    return RecommendationPriority.Good;
                }

                // Si core <= 0, no marcamos nada (neutral); seguimos buscando por si otro hijo es Good
            }

            // Sin hijos Good ⇒ neutral
            Trace($"Folder={(ownerBp != null ? ownerBp.name : "(null)")} RESULT=Same (no eligible Good)");
            return RecommendationPriority.Same;
        }

        // --- Helpers ---

        private static BlueprintScriptableObject GetOwnerBlueprint(LevelUpRecommendationComponent c)
        {
            try
            {
                var prop = c.GetType().GetProperty("OwnerBlueprint",
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (prop != null) return prop.GetValue(c) as BlueprintScriptableObject;
            }
            catch { }
            return null;
        }

        private static bool IsHiddenInUI(BlueprintFeature feat)
        {
            if (feat.HideInUI) return true;

            if (feat is BlueprintFeatureBase asBase)
            {
                var pi = typeof(BlueprintFeatureBase).GetProperty(
                    "HideNotAvailibleInUI",
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (pi != null)
                {
                    try
                    {
                        if (pi.GetValue(asBase) is bool b && b) return true;
                    }
                    catch { }
                }
            }
            return false;
        }

        /// Determina pertenencia al pool comparando GRUPOS (robusto) y, si se puede, colecciones de la selección.
        private static bool IsInSelectionPool(FeatureSelectionState selectionState, BlueprintFeature feat)
        {
            var sel = selectionState?.Selection;
            if (sel == null) return true;

            if (sel is BlueprintFeatureSelection bfs)
            {
                var selGroups = GetSelectionGroups(bfs);
                var featGroups = GetFeatureGroups(feat);

                if (selGroups.Length > 0 && featGroups.Length > 0 && featGroups.Intersect(selGroups).Any())
                    return true;

                // Fallbacks
                if (ContainsRefArray(bfs, "m_AllFeaturesCached", feat)) return true;
                if (ContainsRefArray(bfs, "m_AllFeatures", feat)) return true;
                if (ContainsRefArray(bfs, "m_Features", feat)) return true;
                if (ContainsFeatEnumerable(bfs, "AllFeatures", feat)) return true;
            }

            // Fallbacks genéricos
            if (ContainsRefArray(sel, "m_AllFeaturesCached", feat)) return true;
            if (ContainsRefArray(sel, "m_AllFeatures", feat)) return true;
            if (ContainsRefArray(sel, "m_Features", feat)) return true;
            if (ContainsFeatEnumerable(sel, "AllFeatures", feat)) return true;
            if (ContainsFeatEnumerable(sel, "Features", feat)) return true;
            if (ContainsFeatEnumerable(sel, "Items", feat)) return true;

            // Si no podemos probar que no está, no bloqueamos por pool
            return true;
        }

        private static Kingmaker.Blueprints.Classes.FeatureGroup[] GetSelectionGroups(BlueprintFeatureSelection bfs)
        {
            try
            {
                var p1 = bfs.GetType().GetProperty("Group", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                var p2 = bfs.GetType().GetProperty("Group2", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                var pArr = bfs.GetType().GetProperty("Groups", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                var list = new System.Collections.Generic.List<Kingmaker.Blueprints.Classes.FeatureGroup>();
                if (pArr?.GetValue(bfs) is Kingmaker.Blueprints.Classes.FeatureGroup[] arr && arr.Length > 0) list.AddRange(arr);
                if (p1?.GetValue(bfs) is Kingmaker.Blueprints.Classes.FeatureGroup g1) list.Add(g1);
                if (p2?.GetValue(bfs) is Kingmaker.Blueprints.Classes.FeatureGroup g2) list.Add(g2);

                return list.Where(g => g != 0).Distinct().ToArray();
            }
            catch { return Array.Empty<Kingmaker.Blueprints.Classes.FeatureGroup>(); }
        }

        private static Kingmaker.Blueprints.Classes.FeatureGroup[] GetFeatureGroups(BlueprintFeature feat)
        {
            try
            {
                var p = feat.GetType().GetProperty("Groups", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (p?.GetValue(feat) is Kingmaker.Blueprints.Classes.FeatureGroup[] arr) return arr ?? Array.Empty<Kingmaker.Blueprints.Classes.FeatureGroup>();
            }
            catch { }
            return Array.Empty<Kingmaker.Blueprints.Classes.FeatureGroup>();
        }

        private static bool MeetsPrereqsNative(
            BlueprintFeature feat, UnitDescriptor unit, LevelUpState state, FeatureSelectionState selectionState)
        {
            try
            {
                return feat.MeetsPrerequisites(selectionState, unit, state, fromProgression: false, onlyWhiteListed: false);
            }
            catch { return false; }
        }

        private static bool ContainsRefArray(object obj, string member, BlueprintFeature feat)
        {
            var t = obj.GetType();

            var fi = t.GetField(member, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (fi?.GetValue(obj) is BlueprintFeatureReference[] f1 &&
                f1.Any(r => ReferenceEquals(r?.Get(), feat)))
                return true;

            var pi = t.GetProperty(member, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (pi?.GetValue(obj) is BlueprintFeatureReference[] f2 &&
                f2.Any(r => ReferenceEquals(r?.Get(), feat)))
                return true;

            return false;
        }

        private static bool ContainsFeatEnumerable(object obj, string member, BlueprintFeature feat)
        {
            var pi = obj.GetType().GetProperty(member, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (pi?.GetValue(obj) is System.Collections.IEnumerable en)
            {
                foreach (var x in en)
                    if (ReferenceEquals(x, feat)) return true;
            }
            return false;
        }

        private static string SelName(FeatureSelectionState s)
        {
            var sel = s?.Selection;
            if (sel is BlueprintScriptableObject bp) return bp.name;
            if (sel is UnityEngine.Object uo) return uo.name;
            return sel?.GetType().Name ?? "(no-sel)";
        }
    }
}
*/