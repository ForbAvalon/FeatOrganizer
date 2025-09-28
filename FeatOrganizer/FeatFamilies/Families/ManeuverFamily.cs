using FeatOrganizer.Features.Families;

namespace FeatOrganizer.FeatFamilies.Families
{
    internal static class ManeuverFeatFamily
    {
        // --- Selection meta ---
        private const string SelectionGuid = "8d2f1c3a-7b64-4e29-9f1a-3c8b7e2d5a6c";
        private const string SelectionInternal = "FF.ManeuverFeats";
        private const string SelectionNameKey = "FF.ManeuverFeats.Name";
        private const string SelectionName = "Maneuver Feats";
        private const string SelectionDescKey = "FF.ManeuverFeats.Desc";
        private const string SelectionDesc = "A collection of maneuver feats.";

        // --- Feats (0..N) ---
        private const string FurysFall = "0fc1ed8532168f74a9441bd17ad59e66";
        private const string GreaterBullRush = "72ba6ad46d94ecd41bad8e64739ea392";
        private const string GreaterDirtyTrick = "52c6b07a68940af41b270b3710682dc7";
        private const string GreaterDisarm = "63d8e3a9ab4d72e4081a7862d7246a79";
        private const string GreaterSunder = "54d824028117e884a8f9356c7c66149b";
        private const string GreaterTrip = "4cc71ae82bdd85b40b3cfe6697bb7949";
        private const string ImprovedBullRush = "b3614622866fe7046b787a548bbd7f59";
        private const string ImprovedDirtyTrick = "ed699d64870044b43bb5a7fbe3f29494";
        private const string ImprovedDisarm = "25bc9c439ac44fd44ac3b1e58890916f";
        private const string DisarmingStrike = "3af3476f6034a924e96f3ffa198424b7";
        private const string ImprovedSunder = "9719015edcbf142409592e2cbaab7fe1";
        private const string ImprovedTrip = "0f15c6f70d8fb2b49aa6cc24239cc5fa";
        private const string AgileManeuvers = "197306972c98bb843af738dc7529a7ac";

        // --- Families (0..N) ---
        

        private static readonly string[] MemberGuids =
        {
            ImprovedBullRush,
            FurysFall,
            GreaterBullRush,
            GreaterDirtyTrick,
            GreaterDisarm,
            GreaterSunder,
            GreaterTrip,
            ImprovedDirtyTrick,
            ImprovedDisarm,
            DisarmingStrike,
            ImprovedSunder,
            ImprovedTrip,
            AgileManeuvers
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
