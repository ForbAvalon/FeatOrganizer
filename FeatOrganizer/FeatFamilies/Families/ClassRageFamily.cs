using FeatOrganizer.Features.Families;

namespace FeatOrganizer.FeatFamilies.Families
{
    internal static class ClassRageFeatFamily
    {
        // --- Selection meta ---
        private const string SelectionGuid = "e3f7a2c1-5b46-4c8d-9a21-7f0c3b5d2a84";
        private const string SelectionInternal = "FF.ClassRageFeats";
        private const string SelectionNameKey = "FF.ClassRageFeats.Name";
        private const string SelectionName = "Class Rage Feats";
        private const string SelectionDescKey = "FF.ClassRageFeats.Desc";
        private const string SelectionDesc = "A collection of rage feats.";

        // --- Feats (0..N) ---
        private const string RagingBrutality = "c002fad1506842abb2da5bcedacc358e";
        private const string ExtraBloodRage = "7624c6e46551720459cf5292da67d2f9";
        private const string ExtraRage = "1a54bbbafab728348a015cf9ffcf50a7";
        private const string ExtraRageInstinctualWarrior = "dcc338110bab48ddbdc22e82cef7a6db";

        // --- Families (0..N) ---
        private const string ExtraRagePowerSelection = "0c7f01fbbe687bb4baff8195cb02fe6a";

        private static readonly string[] MemberGuids =
        {
            RagingBrutality,
            ExtraBloodRage,
            ExtraRage,
            ExtraRageInstinctualWarrior
        };

        private static readonly string[] FamilyGuids =
        {
            ExtraRagePowerSelection
        };

        public static void Configure()
        {
            FamilyBuilder.Build(new FamilyBuilder.Spec
            {
                SelectionGuid = SelectionGuid,
                InternalName = SelectionInternal,
                NameKey = SelectionNameKey,
                Name = SelectionName,
                DescKey = SelectionDescKey,
                Desc = SelectionDesc,
                MemberFeats = MemberGuids,
                NestedFamilies = FamilyGuids,
                PlaceInBasic = true,
                RemoveMembersFromBasic = true
            });
        }
    }
}
