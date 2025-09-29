namespace FeatOrganizer.FeatFamilies.Families
{
    internal static class FeintFeatFamily
    {
        // --- Selection meta ---
        private const string SelectionGuid = "3e8f1a24-9c3b-4d72-8f1e-5a0c6b2d9e47";
        private const string SelectionInternal = "FF.FeintFeats";
        private const string SelectionNameKey = "FF.FeintFeats.Name";
        private const string SelectionName = "Feint Feats";
        private const string SelectionDescKey = "FF.FeintFeats.Desc";
        private const string SelectionDesc = "A collection of feint feats.";

        // --- Feats (0..N) ---
        private const string Feint = "c610310d31414edabcedf0c8a6fe32c4";
        private const string FinalFeint = "32429740d6a5470aaaa02f20d61e43d3";
        private const string RangedFeint_ = "a2e947d6be234abba7c3ac0bd5dc9b1d";
        private const string SlayersFeint = "39425a13df904e3cb0e3f6debfe65cab";
        private const string TwoWeaponFeint = "92c7e14b4da24549a9219e990b30d723";
        private const string DivaAdvance = "d05cbf9cca8c4385a76bb6d65f65a717";
        private const string DivaStrike = "3306f4c6913d4d429358b907cdb4ffd1";
        private const string DivaStyle = "b46bf228d6b2427abd028e2fe7b84600";

        // --- Families (0..N) ---


        private static readonly string[] MemberGuids =
        {
            Feint,
            FinalFeint,
            RangedFeint_,
            SlayersFeint,
            TwoWeaponFeint,
            DivaAdvance,
            DivaStrike,
            DivaStyle
        };

        private static readonly string[] FamilyGuids =
        {
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
