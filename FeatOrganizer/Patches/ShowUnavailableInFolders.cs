using FeatOrganizer.Components;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UI.MVVM._VM.CharGen.Phases.FeatureSelector;
using Kingmaker.UI.MVVM._VM.Other.NestedSelectionGroup;
using Kingmaker.UnitLogic.Class.LevelUp;
using Owlcat.Runtime.UI.Tooltips;
using System.Collections.Generic;
using UniRx;

namespace FeatOrganizer.Patches
{
    [HarmonyPatch(typeof(NestedSelectionGroupEntityVM), "SetExpanded")]
    internal static class Patch_AllowExpandForOurFolder_WithoutHasNesting
    {
        private static readonly AccessTools.FieldRef<NestedSelectionGroupEntityVM, ReactiveProperty<bool>>
            _expandedRef = AccessTools.FieldRefAccess<NestedSelectionGroupEntityVM, ReactiveProperty<bool>>("m_IsExpanded");

        static bool Prefix(NestedSelectionGroupEntityVM __instance, bool state)
        {
            if (__instance is CharGenFeatureSelectorItemVM item && IsOurFolderRoot(item))
            {
                var rp = _expandedRef(__instance);
                if (rp != null) rp.Value = state; 
                return false; 
            }
            return true;
        }

        private static bool IsOurFolderRoot(CharGenFeatureSelectorItemVM vm)
        {
            var root = vm;
            while (root.Source is CharGenFeatureSelectorItemVM p) root = p;
            return root?.Feature?.Feature is BlueprintFeatureBase bp && bp.GetComponent<AggregateMemberRecommendations>() != null;
        }
    }

    [HarmonyPatch(typeof(CharGenFeatureSelectorItemVM), nameof(CharGenFeatureSelectorItemVM.ExtractNestedEntities))]
    internal static class Patch_OurFolder_FakeChildren_WhenNoSelectionState
    {
        private static readonly AccessTools.FieldRef<CharGenFeatureSelectorItemVM, LevelUpController>
            _levelUpRef = AccessTools.FieldRefAccess<CharGenFeatureSelectorItemVM, LevelUpController>("m_LevelUpController");

        private static readonly AccessTools.FieldRef<CharGenFeatureSelectorItemVM, ReactiveProperty<TooltipBaseTemplate>>
            _tooltipRef = AccessTools.FieldRefAccess<CharGenFeatureSelectorItemVM, ReactiveProperty<TooltipBaseTemplate>>("m_TooltipTemplate");

        private static readonly AccessTools.FieldRef<CharGenFeatureSelectorItemVM, BoolReactiveProperty>
            _canDropRef = AccessTools.FieldRefAccess<CharGenFeatureSelectorItemVM, BoolReactiveProperty>("m_CanDropLevelupPlan");

        static void Postfix(CharGenFeatureSelectorItemVM __instance, ref List<NestedSelectionGroupEntityVM> __result)
        {
            if (__result != null) return;

            var folderBp = __instance?.Feature?.Feature as BlueprintFeatureBase;
            var comp = folderBp?.GetComponent<AggregateMemberRecommendations>();
            if (comp == null) return; 

            var list = new List<NestedSelectionGroupEntityVM>();
            var levelUp = _levelUpRef(__instance);
            var tooltipProp = _tooltipRef(__instance);
            var canDrop = _canDropRef(__instance);

            foreach (var mRef in comp.Members)
            {
                var feat = mRef?.Get();
                if (feat == null) continue;

                var item = new SimpleFeatureSelectionItem(feat);
                var child = new CharGenFeatureSelectorItemVM(levelUp, item, __instance, tooltipProp, canDrop);
                list.Add(child);
            }

            __result = list;
        }
    }

    internal sealed class SimpleFeatureSelectionItem : IFeatureSelectionItem
    {
        public SimpleFeatureSelectionItem(BlueprintFeature feature)
        {
            Feature = feature;
            Name = feature?.Name ?? string.Empty;
            Description = feature?.Description ?? string.Empty;
            NameForAcronym = feature?.Name ?? string.Empty;
            Icon = feature?.Icon;
            Param = null;
        }

        public BlueprintFeature Feature { get; }
        public FeatureParam Param { get; }

        public string Name { get; }
        public string Description { get; }
        public string NameForAcronym { get; }
        public UnityEngine.Sprite Icon { get; }

        public bool IsSame(IFeatureSelectionItem other)
        {
            if (other == null) return false;
            if (!ReferenceEquals(Feature, other.Feature)) return false;
            if (Param == null && other.Param == null) return true;
            return ReferenceEquals(Param, other.Param);
        }
    }
}
