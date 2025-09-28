using FeatOrganizer.Features.Families;

namespace FeatOrganizer.FeatFamilies.Families
{
    internal static class DefenseFeatFamily
    {
        // --- Selection meta ---
        private const string SelectionGuid = "d4c1a7f0-9b2e-4f53-8a1e-2f6a3cb7e8d9";
        private const string SelectionInternal = "FF.DefenseFeats";
        private const string SelectionNameKey = "FF.DefenseFeats.Name";
        private const string SelectionName = "Defense Feats";
        private const string SelectionDescKey = "FF.DefenseFeats.Desc";
        private const string SelectionDesc = "A collection of defense feats.";

        // --- Feats (0..N) ---
        private const string ArcaneArmorMastery = "453f5181a5ed3a445abfa3bcd3f4ac0c";
        private const string BlindFight = "4e219f5894ad0ea4daa0699e28c37b1d";
        private const string CombatExpertiseFeature = "4c44724ffa8844f4d9bedb5bb27d144a";
        private const string Diehard = "86669ce8759f9d7478565db69b8c19ad";
        private const string Dodge = "97e216dbb46ae3c4faef90cf6bbe6fd5";
        private const string Endurance = "54ee847996c25cd4ba8773d7b8555174";
        private const string GreatFortitude = "79042cb55f030614ea29956177977c52";
        private const string IronWill = "175d1577bb6c9a04baf88eec99c66334";
        private const string LightningReflexes = "15e7da6645a7f3d41bdad7c8c4b9de1e";
        private const string Toughness = "d09b20029e9abfe4480b356c92095623";
        private const string ArcaneArmorTraining = "1a0298abacb6e0f45b7e28553e99e76c";
        private const string DefensiveCombatTraining = "479c7f3b0dba69a4bbcb43e101f3f7f9";
        private const string CautiousFighter = "4a6fbe77a4a2ce24db0cd0b1e4d93db1";
        private const string Mobility = "2a6091b97ad940943b46262600eaeaeb";
        private const string BlindFightGreater = "80a50d9744a40ac4c96e2cc6451a6703";
        private const string BlindFightImproved = "4f1a78b02ac71bd4fa7d6e011d6f8ce0";
        private const string GreatFortitudeImproved = "f5db1cc7ad48d794f85252fa4a64157b";
        private const string IronWillImproved = "3ea2215150a1c8a4a9bfed9d9023903e";
        private const string LightningReflexesImproved = "1e813eb8159b67a459b1c975027866e5";
        private const string LifeDominantSoul = "8f58b4029511b5345981ffaf1da5ea2e";
        private const string MurmursOfEarth = "94be54cd152d1c94396754de7bf0105f";
        private const string SteelSoul = "8bc16857824564d4e9400bbfcdd957fb";
        private const string AcrobaticSpellcaster = "7ba4b4023a7748669098c479dd9e8de6";
        private const string DuelingMastery = "c3a66c1bbd2fb65498b130802d5f183a";

        // --- Families (0..N) ---
        private const string ArmorFocusSelection = "76d4885a395976547a13c5d6bf95b482";

        private static readonly string[] MemberGuids =
        {
            ArcaneArmorMastery,
            BlindFight,
            CombatExpertiseFeature,
            Diehard,
            Dodge,
            Endurance,
            GreatFortitude,
            IronWill,
            LightningReflexes,
            Toughness,
            ArcaneArmorTraining,
            DefensiveCombatTraining,
            CautiousFighter,
            Mobility,
            BlindFightGreater,
            BlindFightImproved,
            GreatFortitudeImproved,
            IronWillImproved,
            LightningReflexesImproved,
            LifeDominantSoul,
            MurmursOfEarth,
            SteelSoul,
            AcrobaticSpellcaster,
            DuelingMastery
        };

        private static readonly string[] FamilyGuids =
        {
            ArmorFocusSelection
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
