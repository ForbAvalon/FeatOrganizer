namespace FeatOrganizer.FeatFamilies.Families
{
    internal static class RaceFeatFamily
    {
        // --- Selection meta ---
        private const string SelectionGuid = "7c9f2e81-4d3a-42b6-9f0b-2d6a1c4e8b73";
        private const string SelectionInternal = "FF.RaceFeats";
        private const string SelectionNameKey = "FF.RaceFeats.Name";
        private const string SelectionName = "Race Feats";
        private const string SelectionDescKey = "FF.RaceFeats.Desc";
        private const string SelectionDesc = "A collection of race feats.";

        // --- Feats (0..N) ---
        private const string FastLearner = "7ad59ca648c14c0a92adec798d51eb6d";
        private const string HistoryOfTerrors = "9e4c7d08f67f4496ba42c2cdb00609a7";
        private const string Ironguts = "90f7164ce17840c68c1ceadcf5d10297";
        private const string Ironhide = "07a8059e18fd42eea61567cb11365a9d";
        private const string LifeDominantSoul = "8f58b4029511b5345981ffaf1da5ea2e";
        private const string MurmursOfEarth = "94be54cd152d1c94396754de7bf0105f";
        private const string SteelSoul = "8bc16857824564d4e9400bbfcdd957fb";
        private const string FeatureWingsAngel = "d9bd0fde6deb2e44a93268f2dfb3e169";
        private const string Razortusk = "86af486a0d92427280c46127a216c85a";
        private const string VulpinePounce = "cd258f1bce80ef54580f6b236c82608c";
        private const string BloodDrinker = "96983d50aca1d214e8adc57a39b41c25";
        private const string BloodFeaster = "e78b4b66db382aa4199f5f2b7da6e5ea";
        private const string ElvenArcaneFocus = "f12795ec2c204d428738bbe1bfcad8fb";
        private const string ElvenSpirit = "191a6ee9ccf849f8b34d34ad93b7af06";
        private const string ElvenImprovedImmunities = "12a62aa4876a4c6b95e8acca7a6f8369";
        private const string MagicalTail = "febb8fe9a2d142fb80c1be6b0b539d9d";
        private const string Shadowplay = "caba7e4dc9b14206bbf667814cc1cb90";
        private const string BreadthOfExperience = "351bfb6ce48d441da02cc141e7f19ed8";
        private const string DIscerningEye = "c4b818bdcea845c9ae8cf277251d70d9";
        private const string EchoesOfStone = "70d3ac68dad02074791f58c8ba09d42f";
        private const string NaturalCharmer = "0ebbc4a0ecf03844384a177e9f1f9a11";
        private const string StonyStep = "c542b083d72f19944a4c6bdf640fc099";

        // --- Families (0..N) ---


        private static readonly string[] MemberGuids =
        {
            FastLearner,
            HistoryOfTerrors,
            Ironguts,
            Ironhide,
            LifeDominantSoul,
            MurmursOfEarth,
            SteelSoul,
            FeatureWingsAngel,
            Razortusk,
            VulpinePounce,
            BloodDrinker,
            BloodFeaster,
            ElvenArcaneFocus,
            ElvenSpirit,
            ElvenImprovedImmunities,
            MagicalTail,
            Shadowplay,
            BreadthOfExperience,
            DIscerningEye,
            EchoesOfStone,
            NaturalCharmer,
            StonyStep
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
