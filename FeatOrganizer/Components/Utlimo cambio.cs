/*using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Recommendations;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Class.LevelUp;

namespace FeatOrganizer.Components
{
    /// Marca la carpeta Good si (y solo si) tiene ≥1 hijo visible,
    /// en el pool actual (por grupos públicos), elegible ahora y recomendado por el core.
    [Serializable]
    public class AggregateMemberRecommendations : LevelUpRecommendationComponent
    {
        public BlueprintFeatureReference[] Members = Array.Empty<BlueprintFeatureReference>();

        // ---------- Cachés (0 reflexión) ----------
        private static readonly ConditionalWeakTable<BlueprintFeatureSelection, FeatureGroup[]> SelGroupsCWT
            = new ConditionalWeakTable<BlueprintFeatureSelection, FeatureGroup[]>();

        private static readonly ConditionalWeakTable<BlueprintFeature, FeatureGroup[]> FeatGroupsCWT
            = new ConditionalWeakTable<BlueprintFeature, FeatureGroup[]>();

        private static readonly ConditionalWeakTable<LevelUpState, Dictionary<BlueprintFeature, int>> CoreRecCWT
            = new ConditionalWeakTable<LevelUpState, Dictionary<BlueprintFeature, int>>();

        private static readonly ConditionalWeakTable<LevelUpState, Dictionary<BlueprintFeature, bool>> PrereqCWT
            = new ConditionalWeakTable<LevelUpState, Dictionary<BlueprintFeature, bool>>();

        // Resueltos y preindexados (por instancia del componente)
        [NonSerialized] private BlueprintFeature[] _features; // Members resueltos
        [NonSerialized] private Dictionary<FeatureGroup, List<BlueprintFeature>> _byGroup; // índice rápido por grupo
        [NonSerialized] private bool _initialized;

        public override RecommendationPriority GetPriority(LevelUpState state)
        {
            if (state == null || state.Unit == null)
                return RecommendationPriority.Same;

            // Inicialización perezosa (sin reflexión)
            EnsureInitialized();

            if (_features == null || _features.Length == 0)
                return RecommendationPriority.Same;

            // Selección visible/actual (la última)
            FeatureSelectionState evalSel = null;
            var selCount = state.Selections != null ? state.Selections.Count : 0;
            if (selCount > 0)
                evalSel = state.Selections[selCount - 1];

            var bfs = evalSel != null ? evalSel.Selection as BlueprintFeatureSelection : null;
            if (bfs == null)
                return RecommendationPriority.Same;

            var selGroups = SelGroupsCWT.GetValue(bfs, GetSelectionGroupsPublic);
            if (selGroups == null || selGroups.Length == 0)
                return RecommendationPriority.Same;

            // Recolectar candidatos por grupos de la selección (evita recorrer todos los Members)
            // Usamos un set para evitar duplicados si un feat está en varios grupos.
            var candidates = Pool<HashSet<BlueprintFeature>>.Get();
            try
            {
                for (int i = 0; i < selGroups.Length; i++)
                {
                    List<BlueprintFeature> list;
                    if (_byGroup != null && _byGroup.TryGetValue(selGroups[i], out list) && list != null)
                    {
                        for (int j = 0; j < list.Count; j++)
                            candidates.Add(list[j]);
                    }
                }

                if (candidates.Count == 0)
                    return RecommendationPriority.Same;

                // Cachés por LevelUpState
                var coreMap = CoreRecCWT.GetValue(state, _ => new Dictionary<BlueprintFeature, int>(64));
                var prereqMap = PrereqCWT.GetValue(state, _ => new Dictionary<BlueprintFeature, bool>(64));

                // Evaluación de candidatos
                foreach (var feat in candidates)
                {
                    if (feat == null) continue;

                    // Oculto / ya conocido
                    if (feat.HideInUI || state.Unit.HasFact(feat))
                        continue;

                    // Prereqs con caché
                    bool ok;
                    if (!prereqMap.TryGetValue(feat, out ok))
                    {
                        ok = MeetsPrereqs(feat, state.Unit, state, evalSel);
                        prereqMap[feat] = ok;
                    }
                    if (!ok)
                        continue;

                    // Filtro rápido: ¿tiene algún componente de recomendación?
                    if (!MayHaveCoreRecommendation(feat))
                        continue;

                    // Core recommendation con caché
                    int core;
                    if (!coreMap.TryGetValue(feat, out core))
                    {
                        try { core = LevelUpRecommendationEx.GetRecommendationPriority(feat, state); }
                        catch { core = 0; }
                        coreMap[feat] = core;
                    }

                    if (core > 0)
                        return RecommendationPriority.Good;
                }
            }
            finally
            {
                candidates.Clear();
                Pool<HashSet<BlueprintFeature>>.Return(candidates);
            }

            return RecommendationPriority.Same;
        }

        // ---------- Init / helpers ----------

        private void EnsureInitialized()
        {
            if (_initialized) return;
            _initialized = true;

            // Resolver una vez las refs -> features
            if (Members == null || Members.Length == 0)
            {
                _features = Array.Empty<BlueprintFeature>();
                _byGroup = null;
                return;
            }

            var temp = new List<BlueprintFeature>(Members.Length);
            for (int i = 0; i < Members.Length; i++)
            {
                var f = Members[i] != null ? Members[i].Get() : null;
                if (f != null) temp.Add(f);
            }
            _features = temp.Count > 0 ? temp.ToArray() : Array.Empty<BlueprintFeature>();

            if (_features.Length == 0)
            {
                _byGroup = null;
                return;
            }

            // Construir índice por grupo para filtrar rápido por selección
            _byGroup = new Dictionary<FeatureGroup, List<BlueprintFeature>>(8);
            for (int i = 0; i < _features.Length; i++)
            {
                var f = _features[i];
                var groups = FeatGroupsCWT.GetValue(f, GetFeatureGroupsPublic);

                if (groups == null || groups.Length == 0)
                    continue;

                for (int g = 0; g < groups.Length; g++)
                {
                    List<BlueprintFeature> list;
                    if (!_byGroup.TryGetValue(groups[g], out list))
                    {
                        list = new List<BlueprintFeature>(4);
                        _byGroup.Add(groups[g], list);
                    }
                    list.Add(f);
                }
            }
        }

        private static bool MeetsPrereqs(
            BlueprintFeature feat, UnitDescriptor unit, LevelUpState state, FeatureSelectionState selectionState)
        {
            try
            {
                return feat.MeetsPrerequisites(selectionState, unit, state, fromProgression: false, onlyWhiteListed: false);
            }
            catch
            {
                return false;
            }
        }

        /// Rápido: si el feat no tiene componentes de recomendación, casi seguro que GetRecommendationPriority devolverá 0.
        private static bool MayHaveCoreRecommendation(BlueprintFeature feat)
        {
            var comps = feat.ComponentsArray;
            if (comps == null || comps.Length == 0) return false;

            for (int i = 0; i < comps.Length; i++)
            {
                if (comps[i] is LevelUpRecommendationComponent)
                    return true;
            }
            return false;
        }

        private static FeatureGroup[] GetSelectionGroupsPublic(BlueprintFeatureSelection bfs)
        {
            // Usamos solo propiedades públicas/sin reflexión
            // bfs.Groups puede ser null; Group/Group2 pueden existir en algunos builds.
            // Reunimos y eliminamos duplicados sin LINQ.
            var tmp = new List<FeatureGroup>(4);

            var groups = bfs.Groups;
            if (groups != null && groups.Length > 0)
            {
                for (int i = 0; i < groups.Length; i++)
                    if (groups[i] != 0) tmp.Add(groups[i]);
            }

#pragma warning disable CS0618
            if (bfs.Group != 0) tmp.Add(bfs.Group);
            if (bfs.Group2 != 0) tmp.Add(bfs.Group2);
#pragma warning restore CS0618

            if (tmp.Count == 0) return Array.Empty<FeatureGroup>();

            // unique
            var seen = Pool<HashSet<FeatureGroup>>.Get();
            var result = new List<FeatureGroup>(tmp.Count);
            try
            {
                for (int i = 0; i < tmp.Count; i++)
                {
                    var g = tmp[i];
                    if (!seen.Contains(g))
                    {
                        seen.Add(g);
                        result.Add(g);
                    }
                }
            }
            finally
            {
                seen.Clear();
                Pool<HashSet<FeatureGroup>>.Return(seen);
            }

            return result.Count > 0 ? result.ToArray() : Array.Empty<FeatureGroup>();
        }

        private static FeatureGroup[] GetFeatureGroupsPublic(BlueprintFeature feat)
        {
            var arr = feat.Groups;
            return arr ?? Array.Empty<FeatureGroup>();
        }

        // ---------- Pool simple para sets/listas temporales ----------
        private static class Pool<T> where T : class, new()
        {
            private static readonly Stack<T> _stack = new Stack<T>(8);

            public static T Get()
            {
                return _stack.Count > 0 ? _stack.Pop() : new T();
            }

            public static void Return(T obj)
            {
                if (obj == null) return;
                _stack.Push(obj);
            }
        }
    }
}
*/