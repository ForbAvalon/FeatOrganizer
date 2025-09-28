using FeatOrganizer.Features.Families;

namespace FeatOrganizer.FeatFamilies.Families
{
    internal static class UnarmedFeatFamily
    {
        // --- Selection meta ---
        private const string SelectionGuid = "b1e7d3c2-48a9-4f0e-9b6a-2d4c7f8a5e31";
        private const string SelectionInternal = "FF.UnarmedFeats";
        private const string SelectionNameKey = "FF.UnarmedFeats.Name";
        private const string SelectionName = "Unarmed Feats";
        private const string SelectionDescKey = "FF.UnarmedFeats.Desc";
        private const string SelectionDesc = "A collection of unarmed feats.";

        // --- Feats (0..N) ---
        private const string ImprovedUnarmedStrike = "7812ad3672a4b9a4fb894ea402095167";
        private const string BoarFerocity = "c450b2902b1f4ebdbdd5063260823b57";
        private const string BoarShred = "bfd867bce95e420e82b3c96abb133876";
        private const string BoarStyle = "0641368c74334671aaaf32a2730587be";
        private const string DragonRoarFeature = "3fca938ad6a5b8348a8523794127c5bc";
        private const string DragonStyle = "87ec6541cddfa394ab540dd13399d319";
        private const string PummelingStyle = "c36562b8e7ae12d408487ba8b532d966";
        private const string SculptingTheRiver = "57c3ea6b05da4226aaeeb21da04e82ea";
        private const string ShaitanEarthblastFeature = "204a749f60f443e29fbb9e8f6da0a14d";
        private const string StunningFist = "a29a582c3daa4c24bb0e991c596ccb28";
        private const string DragonFerocity = "2a681cb9fcaab664286cb36fff761245";
        private const string CraneStyleRiposteFeat = "59eb2a5507975244c893402d582bf77b";
        private const string CraneStyleFeat = "0c17102f650d9044290922b0fad9132f";
        private const string CraneStyleWingFeat = "af0aae1b973114f47a19ea532237b5fc";
        private const string PummelingBully = "bdf58317985383540920c723db07aa3b";
        private const string PummelingCharge = "c5a39c8f1a2d6824ca565e6c1e4075a5";
        private const string ShaitanSkinFeature = "60d57680c3f64539b72423b3dbcd38cd";
        private const string ShaitanStyleFeature = "c5e2aa13b1b6470d8ec70a962ddabdbd";
        private const string CrushingBlowFeature = "4153755355a0b9b4e956c9ca232c22cf";
        private const string ElementalFistFeature = "5d7c3a3eed0546a598e3d2a1c7e0026a";
        private const string PerfectStrikeFeature = "7477e2e0b72f4ce4fb674f4b21d5e81d";

        // --- Families (0..N) ---
        

        private static readonly string[] MemberGuids =
        {
            ImprovedUnarmedStrike,
            BoarFerocity,
            BoarShred,
            BoarStyle,
            DragonRoarFeature,
            DragonStyle,
            PummelingStyle,
            SculptingTheRiver,
            ShaitanEarthblastFeature,
            StunningFist,
            DragonFerocity,
            CraneStyleRiposteFeat,
            CraneStyleFeat,
            CraneStyleWingFeat,
            PummelingBully,
            PummelingCharge,
            ShaitanSkinFeature,
            ShaitanStyleFeature,
            CrushingBlowFeature,
            ElementalFistFeature,
            PerfectStrikeFeature
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
