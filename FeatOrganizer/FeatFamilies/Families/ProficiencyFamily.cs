namespace FeatOrganizer.FeatFamilies.Families
{
    internal static class ProficiencyFeatFamily
    {
        // --- Selection meta ---
        private const string SelectionGuid = "c4a0f6d2-0b8a-4e6d-b2f7-8f3c1d9a6b25";
        private const string SelectionInternal = "FF.ProficiencyFeats";
        private const string SelectionNameKey = "FF.ProficiencyFeats.Name";
        private const string SelectionName = " Proficiency Feats";
        private const string SelectionDescKey = "FF.ProficiencyFeats.Desc";
        private const string SelectionDesc = "A collection of proficiency feats.";

        // --- Feats (0..N) ---
        private const string MartialWeaponProficiency = "203992ef5b35c864390b4e4a1e200629";
        private const string SimpleWeaponProficiency = "e70ecf1ed95ca2f40b754f1adb22bbdd";
        private const string LightArmorProficiency = "6d3728d4e9c9898458fe5e9532951132";
        private const string MediumArmorProficiency = "46f4fb320f35704488ba3d513397789d";
        private const string HeavyArmorProficiency = "1b0f68188dcc435429fb87a022239681";
        private const string LightBardingProficiency = "c62ba548b1a34b94b9802925b35737c2";
        private const string MediumBardingProficiency = "7213b7bd026d4414da2308df23715d8f";
        private const string HeavyBardingProficiency = "aed0b33e17a3b3d44a718852e87305bd";
        private const string ShieldsProficiency = "cb8686e7357a68c42bdd9d4e65334633";
        private const string TowerShieldProficiency = "6105f450bb2acbd458d277e71e19d835";

        // --- Families (0..N) ---
        private const string ExoticWeaponProficiencySelection = "9a01b6815d6c3684cb25f30b8bf20932";

        private static readonly string[] MemberGuids =
        {
            MartialWeaponProficiency,
            SimpleWeaponProficiency,
            LightArmorProficiency,
            MediumArmorProficiency,
            HeavyArmorProficiency,
            LightBardingProficiency,
            MediumBardingProficiency,
            HeavyBardingProficiency,
            ShieldsProficiency,
            TowerShieldProficiency
        };

        private static readonly string[] FamilyGuids =
        {
            ExoticWeaponProficiencySelection
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
