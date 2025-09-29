/*using System;
using System.Linq;
using System.Reflection;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection; // IFeatureSelection, BlueprintFeatureSelection
using Kingmaker.Designers.Mechanics.Recommendations;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Class.LevelUp;

namespace FeatOrganizer.Components
{
    /// Recomienda la “carpeta” si (y solo si) tiene al menos 1 hijo visible, en el pool actual y elegible ahora.
    [Serializable]
    public class AggregateMemberRecommendations : LevelUpRecommendationComponent
    {
        public BlueprintFeatureReference[] Members = Array.Empty<BlueprintFeatureReference>();

        public override RecommendationPriority GetPriority(LevelUpState state)
        {
            if (state?.Unit == null || Members == null || Members.Length == 0)
                return RecommendationPriority.Same;

            var unit = state.Unit;

            // NUEVO: intenta localizar la selección que realmente contiene cada feat
            FeatureSelectionState FindOwnerSelection(BlueprintFeature f)
                => state.Selections.FirstOrDefault(sel => IsInSelectionPool(sel, f));

            bool anyEligible = false;
            var best = RecommendationPriority.Same;

            static int Score(RecommendationPriority p) =>
                p == RecommendationPriority.Good ? 1 :
                p == RecommendationPriority.Same ? 0 : -1;

            foreach (var m in Members)
            {
                var feat = m?.Get();
                if (feat?.ComponentsArray == null) continue;

                if (unit.HasFact(feat)) continue;           // ya aprendido
                if (IsHiddenInUI(feat)) continue;           // oculto

                var ownerSel = FindOwnerSelection(feat);    // selección dueña (puede ser null)

                // prerequisitos con la lógica nativa de la UI
                if (!MeetsPrereqsNative(feat, unit, state, ownerSel)) continue;

                anyEligible = true;

                foreach (var rec in feat.ComponentsArray.OfType<LevelUpRecommendationComponent>())
                {
                    var prio = rec.GetPriority(state);
                    if (Score(prio) > Score(best)) best = prio;
                    if (best == RecommendationPriority.Good) return best;
                }
            }

            return anyEligible ? best : RecommendationPriority.Same;
        }


        /// Oculto para la UI: HideInUI (en Feature) y HideNotAvailibleInUI (en FeatureBase).
        private static bool IsHiddenInUI(BlueprintFeature feat)
        {
            if (feat.HideInUI) return true;

            // HideNotAvailibleInUI está en BlueprintFeatureBase (ojo a la ortografía).
            // Accedemos tipado si podemos; si no, reflexión segura.
            if (feat is BlueprintFeatureBase asBase)
            {
                // Intento por reflexión para no romper builds donde el miembro sea no-público.
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

        // Cambia la firma para recibir la FeatureSelectionState concreta
        private static bool IsInSelectionPool(FeatureSelectionState selectionState, BlueprintFeature feat)
        {
            var sel = selectionState?.Selection;
            if (sel == null) return true; // sin selección concreta, no filtramos

            if (sel is BlueprintFeatureSelection bfs)
            {
                if (ContainsRefArray(bfs, "m_AllFeaturesCached", feat)) return true;
                if (ContainsRefArray(bfs, "m_AllFeatures", feat)) return true;
                if (ContainsRefArray(bfs, "m_Features", feat)) return true;
                if (ContainsFeatEnumerable(bfs, "AllFeatures", feat)) return true;
            }

            if (ContainsRefArray(sel, "m_AllFeaturesCached", feat)) return true;
            if (ContainsRefArray(sel, "m_AllFeatures", feat)) return true;
            if (ContainsRefArray(sel, "m_Features", feat)) return true;
            if (ContainsFeatEnumerable(sel, "AllFeatures", feat)) return true;
            if (ContainsFeatEnumerable(sel, "Features", feat)) return true;
            if (ContainsFeatEnumerable(sel, "Items", feat)) return true;

            return false;
        }

        private static bool MeetsPrereqsNative(
            BlueprintFeature feat, UnitDescriptor unit, LevelUpState state, FeatureSelectionState selectionState)
        {
            try
            {
                // selectionState puede ser null (la implementación lo tolera)
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
    }
}*/
