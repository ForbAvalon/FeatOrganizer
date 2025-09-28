using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;
using System.Collections.Generic;
using System.Linq;

namespace FeatOrganizer.Features.Families
{
    internal static class MeleeFeatFamily
    {
        private const string FeatsSelectionGuid = "f2a1c3d4-7b89-4e2f-9a5b-3c1d2e4f6a78";
        private const string SelectionInternalName = "FF.MeleeFeat";
        private const string SelectionNameKey = "FF.MeleeFeat.Name";
        private const string SelectionDescKey = "FF.MeleeFeat.Desc";

        // Feats
        private const string PowerAttackFeature = "9972f33f977fc724c838e59641b2fca5";
        private const string WeaponFinesse = "90e54424d682d104ab36436bd527af09";
        private const string CombatReflexes = "0f8939ae6f220984e8fb568abbdfba95";
        private const string CleavingFinish = "59bd93899149fa44687ff4121389b3a9";
        private const string ImprovedCleavingFinish = "ffa1b373190af4f4db7a5501904a1983";
        private const string PiranhaStrikeFeature = "6a556375036ac8b4ebd80e74d308d108";
        private const string CleaveFeature = "d809b6c4ff2aaff4fa70d712a70f7d7b";
        private const string FuriousFocus = "f09b89812cc94b89a09069671002b899";
        private const string GreatCleaveFeature = "cc9c862ef2e03af4f89be5088851ea35";
        private const string VitalStrikeFeatureGreater = "e2d1fa11f6b095e4fb2fd1dcf5e36eb3";
        private const string VitalStrikeFeatureImproved = "52913092cd018da47845f36e6fbe240f";
        private const string LungeFeature = "d41d5bd9a775d7245929256d58a3e03e";
        private const string RagingBrutality = "c002fad1506842abb2da5bcedacc358e";
        private const string VitalStrikeFeature = "14a1fc1356df9f146900e1e42142fc9d";

        // Families
        private const string FencingGrace = "47b352ea0f73c354aba777945760b441";
        private const string SlashingGrace = "697d64669eb2c0543abb9c9b07998a38";

        private static readonly string[] MemberGuids =
        {
            PowerAttackFeature,
            WeaponFinesse,
            CombatReflexes,
            CleavingFinish,
            ImprovedCleavingFinish,
            PiranhaStrikeFeature,
            CleaveFeature,
            FuriousFocus,
            GreatCleaveFeature,
            VitalStrikeFeatureGreater,
            VitalStrikeFeatureImproved,
            LungeFeature,
            RagingBrutality,
            VitalStrikeFeature
        };

        private static readonly string[] FamilyGuids =
        {
            FencingGrace,
            SlashingGrace
        };

        public static void Configure()
        {
            var name = LocalizationTool.CreateString(SelectionNameKey, "Melee Feats", tagEncyclopediaEntries: false);
            var desc = LocalizationTool.CreateString(SelectionDescKey, "A collection of melee combat feats.", tagEncyclopediaEntries: false);

            var pbsFeat = BlueprintTool.Get<BlueprintFeature>(PowerAttackFeature);

            var memberRefs = MemberGuids
                .Select(g => BlueprintTool.GetRef<BlueprintFeatureReference>(g))
                .ToArray();

            FeatureTag aggregatedTags = FeatureTag.None;

            void AccumulateTagsFrom(string guid)
            {
                var bp = BlueprintTool.Get<BlueprintFeature>(guid);
                if (bp?.ComponentsArray == null) return;

                foreach (var c in bp.ComponentsArray.OfType<FeatureTagsComponent>())
                    aggregatedTags |= c.FeatureTags;
            }

            foreach (var guid in MemberGuids)
                AccumulateTagsFrom(guid);

            var familyCfg = FeatureSelectionConfigurator.New(SelectionInternalName, FeatsSelectionGuid)
                .SetDisplayName(name)
                .SetDescription(desc)
                .SetIsClassFeature(true)
                .SetGroups(FeatureGroup.Feat) // solo feats comunes
                .SetIcon(pbsFeat.Icon)
                .AddComponent<FeatureTagsComponent>(c => { c.FeatureTags = aggregatedTags; })
                .AddComponent<FeatOrganizer.Components.AggregateMemberRecommendations>(c =>
                {
                    c.Members = memberRefs;  
                });

            foreach (var r in memberRefs)
                familyCfg = familyCfg.AddToAllFeatures(r);

            var familyRefs = FamilyGuids
                .Select(g => BlueprintTool.GetRef<BlueprintFeatureReference>(g))
                .ToArray();

            foreach (var fr in familyRefs)
                familyCfg = familyCfg.AddToAllFeatures(fr);

            var family = familyCfg.Configure();

            var basic = FeatureSelectionRefs.BasicFeatSelection.Reference.Get();
            var toRemove = new HashSet<BlueprintGuid>(MemberGuids.Select(BlueprintGuid.Parse));

            var features = (basic.m_AllFeatures != null)
                ? new List<BlueprintFeatureReference>(basic.m_AllFeatures)
                : new List<BlueprintFeatureReference>();

            features.RemoveAll(r =>
                r == null
             || toRemove.Contains(r.deserializedGuid)
             || toRemove.Contains(r.Guid)
             || (r.Get() != null && toRemove.Contains(r.Get().AssetGuid))
            );

            var familyRef = family.ToReference<BlueprintFeatureReference>();
            bool hasFamily = features.Exists(r =>
                r != null && (
                    r.deserializedGuid == family.AssetGuid
                 || r.Guid == family.AssetGuid
                 || (r.Get() != null && r.Get().AssetGuid == family.AssetGuid)));

            if (!hasFamily) features.Add(familyRef);

            basic.m_AllFeatures = features.ToArray();
        }
    }
}

