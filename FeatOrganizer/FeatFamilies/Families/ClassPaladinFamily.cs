using FeatOrganizer.Features.Families;

namespace FeatOrganizer.FeatFamilies.Families
{
    internal static class ClassPaladinFeatFamily
    {
        // --- Selection meta ---
        private const string SelectionGuid = "9a1f3c7e-2b58-4d9a-8c3e-1f2a6b7c9d0e";
        private const string SelectionInternal = "FF.ClassPaladinFeats";
        private const string SelectionNameKey = "FF.ClassPaladinFeats.Name";
        private const string SelectionName = "Class Paladin Feats";
        private const string SelectionDescKey = "FF.ClassPaladinFeats.Desc";
        private const string SelectionDesc = "A collection of paladin feats.";

        // --- Feats (0..N) ---
        private const string ExtraLayOnHands = "a2b2f20dfb4d3ed40b9198e22be82030";

        // --- Families (0..N) ---
        private const string ExtraMercySelection = "8a49abed5be9473da1e1fd1e2457562e";

        private static readonly string[] MemberGuids =
        {
            ExtraLayOnHands
        };

        private static readonly string[] FamilyGuids =
        {
            ExtraMercySelection
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
