namespace FeatOrganizer.FeatFamilies.Families
{
    internal static class MountedFeatFamily
    {
        // --- Selection meta ---
        private const string SelectionGuid = "a9c3f2d1-7e5b-46a8-9c1f-2db8476e53a4";
        private const string SelectionInternal = "FF.MountedFeats";
        private const string SelectionNameKey = "FF.MountedFeats.Name";
        private const string SelectionName = "Mounted Feats";
        private const string SelectionDescKey = "FF.MountedFeats.Desc";
        private const string SelectionDesc = "A collection of mounted feats.";

        // --- Feats (0..N) ---
        private const string MountedCombat = "f308a03bea0d69843a8ed0af003d47a9";
        private const string IndomitableMount = "68e814f1f3ce55942a52c1dd536eaa5b";
        private const string MountedShield = "e5bee904e6724fc44aae8887dcefae51";
        private const string SpiritedCharge = "95ef0ff14771f2549897f300ce62c95c";
        private const string Trample = "92db263bfb7445d4aa592a5d15128fc5";
        // --- Families (0..N) ---
        

        private static readonly string[] MemberGuids =
        {
            MountedCombat,
            IndomitableMount,
            MountedShield,
            SpiritedCharge,
            Trample
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
