namespace FeatOrganizer.FeatFamilies.Families
{
    internal static class RangedFeatFamily
    {
        // --- Selection meta ---
        private const string SelectionGuid = "7a3e5b3a-5f6b-4b9e-9f9b-1b2a0a3f9e71";
        private const string SelectionInternal = "FF.RangedFeats";
        private const string SelectionNameKey = "FF.RangedFeats.Name";
        private const string SelectionName = " Ranged Feats";
        private const string SelectionDescKey = "FF.RangedFeats.Desc";
        private const string SelectionDesc = "A collection of ranged combat feats.";

        // --- Feats (0..N) ---
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

        // --- Families (0..N) ---
        private const string PointBlankMaster = "05a3b543b0a0a0346a5061e90f293f0b";

        private static readonly string[] MemberGuids =
        {
            PointBlankShotGuid,
            ThrowAnything,
            DeadlyAimFeature,
            RapidShotFeature,
            ImprovedPreciseShot,
            Manyshot,
            ClusteredShots,
            FocusedShot,
            SnapShotGreater,
            SnapShotImproved,
            SnapShot,
            PreciseShot
        };

        private static readonly string[] FamilyGuids =
        {
            PointBlankMaster
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
