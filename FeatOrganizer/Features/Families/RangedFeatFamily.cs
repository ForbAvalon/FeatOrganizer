using System.Linq;
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
        private const string PointBlankShotGuid = "0da0c194d6e1d43419eb8d990b28e0ab";

        private const string SelectionInternalName = "CO.RangedFeats";
        private const string SelectionNameKey = "CO.RangedFeats.Name";
        private const string SelectionDescKey = "CO.RangedFeats.Desc";

        public static void Configure()
        {
            // Localización SIN tags de enciclopedia
            var name = LocalizationTool.CreateString(SelectionNameKey, "Ranged Feats", tagEncyclopediaEntries: false);
            var desc = LocalizationTool.CreateString(SelectionDescKey, "A collection of ranged combat feats.", tagEncyclopediaEntries: false);

            var pbsRef = BlueprintTool.GetRef<BlueprintFeatureReference>(PointBlankShotGuid);

            var family = FeatureSelectionConfigurator.New(SelectionInternalName, RangedFeatsSelectionGuid)
                .SetDisplayName(name)
                .SetDescription(desc)
                .SetIsClassFeature(true)
                .SetGroups(FeatureGroup.Feat, FeatureGroup.CombatFeat)
                .AddToAllFeatures(pbsRef)
                .Configure();

            // 1) QUITAR PBS SOLO de BasicFeatSelection (trabajando con lista y volviendo a array)
            var basic = FeatureSelectionRefs.BasicFeatSelection.Reference.Get(); // BlueprintFeatureSelection
            var pbsGuid = BlueprintGuid.Parse(PointBlankShotGuid);

            // Pasar a lista para operar cómodos
            var features = (basic.m_AllFeatures != null)
              ? new System.Collections.Generic.List<BlueprintFeatureReference>(basic.m_AllFeatures)
              : new System.Collections.Generic.List<BlueprintFeatureReference>();

            // Quitar cualquier referencia a PBS
            features.RemoveAll(r =>
                r == null
             || r.deserializedGuid == pbsGuid
             || r.Guid == pbsGuid
             || (r.Get() != null && r.Get().AssetGuid == pbsGuid)
            );

            // 2) AÑADIR la “carpeta” a BasicFeatSelection (si no está)
            var familyRef = family.ToReference<BlueprintFeatureReference>();
            bool hasFamily = features.Exists(r =>
                r != null &&
                (r.deserializedGuid == family.AssetGuid
                 || r.Guid == family.AssetGuid
                 || (r.Get() != null && r.Get().AssetGuid == family.AssetGuid))
            );

            if (!hasFamily)
                features.Add(familyRef);

            // Volver a array (tipo correcto del campo)
            basic.m_AllFeatures = features.ToArray();

        }
    }
}
