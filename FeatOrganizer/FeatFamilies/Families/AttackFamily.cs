namespace FeatOrganizer.FeatFamilies.Families
{
    internal static class AttackFeatFamily
    {
        // --- Selection meta ---
        private const string SelectionGuid = "3f2c9a1b-4d8e-4f7a-9c2b-1e5d7a3c9f82";
        private const string SelectionInternal = "FF.AttackFeats";
        private const string SelectionNameKey = "FF.AttackFeats.Name";
        private const string SelectionName = "Attack Feats";
        private const string SelectionDescKey = "FF.AttackFeats.Desc";
        private const string SelectionDesc = "A collection of attack feats.";

        // --- Feats (0..N) ---
        private const string DreadfulCarnage = "fc37b70e3d064a147a3a99db4a86ee12";
        private const string FrighteningAmbush = "805fd6181a104bf0aca9ae79ef220c16";
        private const string GreaterPenetratingStrike = "eb6eb946c68ef094f89c7633f5bfdc9b";
        private const string HammerTheGap = "7b64641c76ff4a744a2bce7f91a20f9a";
        private const string PenetratingStrike = "308cd7dc4f10efd428f531bbf4f2823d";
        private const string ShatterDefenses = "61a17ccbbb3d79445b0926347ec07577";
        private const string AccomplishedSneakAttacker = "9f0187869dc23744292c0e5bb364464e";
        private const string ArcaneStrikeFeature = "0ab2f21a922feee4dab116238e3150b4";
        private const string Disruptive = "f3ef866a9da642c4b9f7dcd76c3567fe";

        // --- Families (0..N) ---


        private static readonly string[] MemberGuids =
        {
            FrighteningAmbush,
            DreadfulCarnage,
            GreaterPenetratingStrike,
            HammerTheGap,
            PenetratingStrike,
            ShatterDefenses,
            AccomplishedSneakAttacker,
            ArcaneStrikeFeature,
            Disruptive
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
