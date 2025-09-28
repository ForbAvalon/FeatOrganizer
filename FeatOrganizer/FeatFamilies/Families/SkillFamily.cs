using FeatOrganizer.Features.Families; // para FamilyBuilder

namespace FeatOrganizer.FeatFamilies
{
    internal static class SkillFeatFamily
    {
        // --- Selection meta ---
        private const string SelectionGuid = "a3f9c5d2-41fb-49f0-9c6d-1e3a74a2d8b1";
        private const string SelectionInternal = "FF.SkillFeats";
        private const string SelectionNameKey = "FF.SkillFeats.Name";
        private const string SelectionName = "Skill Feats";
        private const string SelectionDescKey = "FF.SkillFeats.Desc";
        private const string SelectionDesc = "A collection of skills.";

        // --- Feats (0..N) ---
        private const string FastLearner = "7ad59ca648c14c0a92adec798d51eb6d";
        private const string Alertness = "1c04fe9a13a22bc499ffac03e6f79153";
        private const string BrewPotions = "c0f8c4e513eb493408b8070a1de93fc0";
        private const string DazzlingDisplayFeature = "bcbd674ec70ff6f4894bb5f07b6f4095";
        private const string Deceitful = "231a37321e26551489503e4e1d99e681";
        private const string DeftHands = "ab5fbcd092c860d46a2e62d9dac272e8";
        private const string Persuasive = "86d93a5891d299d4983bdc6ef3987afd";
        private const string ScribingScrolls = "a8a385bf53ee3454593ce9054375a2ec";
        private const string Stealthy = "c7e1d5ef809325943af97f093e149c4f";
        private const string IntimidatingProwess = "d76497bfc48516e45a0831628f767a0f";
        private const string BreadthOfExperience = "351bfb6ce48d441da02cc141e7f19ed8";
        private const string DIscerningEye = "c4b818bdcea845c9ae8cf277251d70d9";
        private const string EchoesOfStone = "70d3ac68dad02074791f58c8ba09d42f";
        private const string NaturalCharmer = "0ebbc4a0ecf03844384a177e9f1f9a11";
        private const string StonyStep = "c542b083d72f19944a4c6bdf640fc099";

        // --- Familias anidadas (0..N) ---
        private const string SkillFocusSelection = "c9629ef9eebb88b479b2fbc5e836656a";


        private static readonly string[] MemberGuids =
        {
            FastLearner,
            Alertness,
            BrewPotions,
            DazzlingDisplayFeature,
            Deceitful,
            DeftHands,
            Persuasive,
            ScribingScrolls,
            Stealthy,
            IntimidatingProwess,
            BreadthOfExperience,
            DIscerningEye,
            EchoesOfStone,
            NaturalCharmer,
            StonyStep
        };

        private static readonly string[] FamilyGuids =
        {
            SkillFocusSelection
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
