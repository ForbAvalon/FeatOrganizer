using FeatOrganizer.Features.Families;

namespace FeatOrganizer.FeatFamilies.Families
{
    internal static class TeamworkFeatFamily
    {
        // --- Selection meta ---
        private const string SelectionGuid = "c8f4a2d7-31d6-4b7e-9c0f-5f2e1a3b7d64";
        private const string SelectionInternal = "FF.TeamworkFeat";
        private const string SelectionNameKey = "FF.TeamworkFeat.Name";
        private const string SelectionName = "Teamwork Feats";
        private const string SelectionDescKey = "FF.TeamworkFeat.Desc";
        private const string SelectionDesc = "A collection of Teamwork feats.";

        // --- Feats (0..N) ---
        private const string AlliedSpellcaster = "9093ceeefe9b84746a5993d619d7c86f";
        private const string CoordinatedDefense = "992fd59da1783de49b135ad89142c6d7";
        private const string CoordinatedManeuvers = "b186cea78dce3a04aacff0a81786008c";
        private const string PreciseStrike = "5662d1b793db90c4b9ba68037fd2a768";
        private const string ShakeItOff = "6337b37f2a7c11b4ab0831d6780bce2a";
        private const string ShieldWall = "8976de442862f82488a4b138a0a89907";
        private const string ShieldedCaster = "0b707584fc2ea724aa72c396c2230dc7";
        private const string BackToBack = "c920f2cd2244d284aa69a146aeefcb2c";
        private const string Outflank = "422dab7309e1ad343935f33a4d6e9f11";
        private const string SiezeTheMoment = "1191ef3065e6f8e4f9fbe1b7e3c0f760";
        private const string TandemTrip = "d26eb8ab2aabd0e45a4d7eec0340bbce";
        private const string VolleyFireFeature = "c4b555225f565bb40a855c1bfeeff07e";
        private const string SpellChain = "d8d641edc9a74a64809f56feff9495b6";

        // --- Families (0..N) ---

        private static readonly string[] MemberGuids =
        {
            AlliedSpellcaster,
            CoordinatedDefense,
            CoordinatedManeuvers,
            PreciseStrike,
            ShakeItOff,
            ShieldWall,
            ShieldedCaster,
            BackToBack,
            Outflank,
            SiezeTheMoment,
            TandemTrip,
            VolleyFireFeature,
            SpellChain
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
