/*using System.Linq;
using System.Collections.Generic;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;

namespace FeatOrganizer.Features.Families
{
    internal static class RangedFeatFamily
    {
        private const string RangedFeatsSelectionGuid = "7a3e5b3a-5f6b-4b9e-9f9b-1b2a0a3f9e71";
        private const string SelectionInternalName = "FF.RangedFeats";
        private const string SelectionNameKey = "FF.RangedFeats.Name";
        private const string SelectionDescKey = "FF.RangedFeats.Desc";

        // Feats
        private const string PointBlankShotGuid = "0da0c194d6e1d43419eb8d990b28e0ab";
        private const string ThrowAnything = "65c538dcfd91930489ad3ab18ad9204b";
        private const string DeadlyAimFeature = "f47df34d53f8c904f9981a3ee8e84892";
        private const string RapidShotFeature = "9c928dc570bb9e54a9649b3ebfe47a41";
        private const string ImprovedPreciseShot = "46f970a6b9b5d2346b10892673fe6e74";
        private const string Manyshot = "adf54af2a681792489826f7fd1b62889";
        private const string ClusteredShots = "f7de245bb20f12f47864c7cb8b1d1abb";
        private const string FocusedShot = "f979ed68d1e74d21962edc66f0a1d169";
        private const string SnapShotGreater = "67b09c86234cecc4c8309f22f7d33973";
        private const string SnapShotImproved = "c3453e7e215c1f149b938be27ac754c6";
        private const string SnapShot = "7115a6c08bd101247b70d72a4ff99453";
        private const string PreciseShot = "8f3d1e6b4be006f4d896081f2f889665";

        // Familia/selección a anidar
        private const string PointBlankMaster = "05a3b543b0a0a0346a5061e90f293f0b";

        private static readonly string[] RangedMemberGuids =
        {
            PointBlankShotGuid, ThrowAnything, DeadlyAimFeature, RapidShotFeature,
            ImprovedPreciseShot, Manyshot, ClusteredShots, FocusedShot,
            SnapShotGreater, SnapShotImproved, SnapShot, PreciseShot
        };

        public static void Configure()
        {
            var name = LocalizationTool.CreateString(SelectionNameKey, "Ranged Feats", tagEncyclopediaEntries: false);
            var desc = LocalizationTool.CreateString(SelectionDescKey, "A collection of ranged combat feats.", tagEncyclopediaEntries: false);

            var pbsFeat = BlueprintTool.Get<BlueprintFeature>(PointBlankShotGuid);

            var memberRefs = RangedMemberGuids
                .Select(g => BlueprintTool.GetRef<BlueprintFeatureReference>(g))
                .ToArray();

            var familyCfg = FeatureSelectionConfigurator.New(SelectionInternalName, RangedFeatsSelectionGuid)
                .SetDisplayName(name)
                .SetDescription(desc)
                .SetIsClassFeature(true)
                .SetGroups(FeatureGroup.Feat)            // ← solo Feat, para que no aparezca en bonus de Guerrero
                .SetIcon(pbsFeat.Icon);

            foreach (var r in memberRefs)
                familyCfg = familyCfg.AddToAllFeatures(r);

            // ← Añade la familia suelta (sub-selección) dentro de esta selección
            var pbmRef = BlueprintTool.GetRef<BlueprintFeatureReference>(PointBlankMaster);
            familyCfg = familyCfg.AddToAllFeatures(pbmRef);

            var family = familyCfg.Configure();

            // Quitar de BasicFeatSelection SOLO los feats sueltos y añadir la carpeta
            var basic = FeatureSelectionRefs.BasicFeatSelection.Reference.Get();
            var toRemove = new HashSet<BlueprintGuid>(RangedMemberGuids.Select(BlueprintGuid.Parse));

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
}*/
