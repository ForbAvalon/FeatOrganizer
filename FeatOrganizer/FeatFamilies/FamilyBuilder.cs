using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FeatOrganizer.FeatFamilies
{
    internal static class FamilyBuilder
    {
        internal sealed class Spec
        {
            internal string SelectionGuid;
            internal string InternalName;
            internal string NameKey;
            internal string Name;
            internal string DescKey;
            internal string Desc;
            internal string[] MemberFeats;    
            internal string[] NestedFamilies; 
            internal bool PlaceInBasic = true;
            internal bool RemoveMembersFromBasic = true;
            internal bool RemoveNestedFromBasic = true;
        }

        internal static BlueprintFeatureSelection Build(Spec spec)
        {
            var name = LocalizationTool.CreateString(spec.NameKey, spec.Name, tagEncyclopediaEntries: false);
            var desc = LocalizationTool.CreateString(spec.DescKey, spec.Desc, tagEncyclopediaEntries: false);

            Sprite icon = null;
            foreach (var g in spec.MemberFeats ?? System.Array.Empty<string>())
            {
                var f = BlueprintTool.Get<BlueprintFeature>(g);
                if (f?.Icon != null) { icon = f.Icon; break; }
            }
            if (icon == null)
            {
                foreach (var g in spec.NestedFamilies ?? System.Array.Empty<string>())
                {
                    var s = BlueprintTool.Get<BlueprintFeature>(g);
                    if (s?.Icon != null) { icon = s.Icon; break; }
                }
            }

            FeatureTag tags = FeatureTag.None;
            foreach (var g in spec.MemberFeats ?? System.Array.Empty<string>())
            {
                var bp = BlueprintTool.Get<BlueprintFeature>(g);
                if (bp?.ComponentsArray == null) continue;
                foreach (var c in bp.ComponentsArray.OfType<FeatureTagsComponent>())
                    tags |= c.FeatureTags;
            }

            var memberRefs = (spec.MemberFeats ?? System.Array.Empty<string>())
                .Select(g => BlueprintTool.GetRef<BlueprintFeatureReference>(g))
                .Where(r => r != null).ToArray();

            var nestedRefs = (spec.NestedFamilies ?? System.Array.Empty<string>())
                .Select(g => BlueprintTool.GetRef<BlueprintFeatureReference>(g))
                .Where(r => r != null).ToArray();

            var cfg = FeatureSelectionConfigurator.New(spec.InternalName, spec.SelectionGuid)
                .SetDisplayName(name)
                .SetDescription(desc)
                .SetIsClassFeature(true)
                .SetGroups(FeatureGroup.Feat);

            if (icon != null) cfg = cfg.SetIcon(icon);
            if (tags != FeatureTag.None)
                cfg = cfg.AddComponent<FeatureTagsComponent>(c => c.FeatureTags = tags);

            if (memberRefs.Length > 0)
                cfg = cfg.AddComponent<Components.AggregateMemberRecommendations>(c => c.Members = memberRefs);

            foreach (var r in memberRefs) cfg = cfg.AddToAllFeatures(r);
            foreach (var r in nestedRefs) cfg = cfg.AddToAllFeatures(r);

            var family = cfg.Configure();

            if (spec.PlaceInBasic)
            {
                var basic = FeatureSelectionRefs.BasicFeatSelection.Reference.Get();
                var features = basic.m_AllFeatures != null
                    ? new List<BlueprintFeatureReference>(basic.m_AllFeatures)
                    : new List<BlueprintFeatureReference>();

                var remove = new HashSet<BlueprintGuid>();
                if (spec.RemoveMembersFromBasic && spec.MemberFeats != null && spec.MemberFeats.Length > 0)
                {
                    foreach (var id in spec.MemberFeats) remove.Add(BlueprintGuid.Parse(id));
                }
                if (spec.RemoveNestedFromBasic && spec.NestedFamilies != null && spec.NestedFamilies.Length > 0)
                {
                    foreach (var id in spec.NestedFamilies) remove.Add(BlueprintGuid.Parse(id));
                }

                if (remove.Count > 0)
                {
                    features.RemoveAll(r =>
                        r == null
                     || remove.Contains(r.deserializedGuid)
                     || remove.Contains(r.Guid)
                     || r.Get() != null && remove.Contains(r.Get().AssetGuid));
                }

                var familyRef = family.ToReference<BlueprintFeatureReference>();
                bool hasFamily = features.Exists(r =>
                    r != null && (
                        r.deserializedGuid == family.AssetGuid
                     || r.Guid == family.AssetGuid
                     || r.Get() != null && r.Get().AssetGuid == family.AssetGuid));

                if (!hasFamily) features.Add(familyRef);
                basic.m_AllFeatures = features.ToArray();
            }

            return family;
        }
    }
}
