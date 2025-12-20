namespace FeatOrganizer.FeatFamilies.Families
{
    internal static class MagicFeatFamily
    {
        // --- Selection meta ---
        private const string SelectionGuid = "e7b2c1a4-3f5b-4c0a-9d3e-8f1a2b7c6d50";
        private const string SelectionInternal = "FF.MagicFeats";
        private const string SelectionNameKey = "FF.MagicFeats.Name";
        private const string SelectionName = " Magic Feats";
        private const string SelectionDescKey = "FF.MagicFeats.Desc";
        private const string SelectionDesc = "A collection of magic feats.";

        // --- Feats (0..N) ---
        private const string AmbuscadingSpell = "2fb48bed3746431bb3080c34f11597da";
        private const string ArcaneSpiritFeat = "e55e2c96ae974bc9ac9fda8b3a56e432";
        private const string CombatCasting = "06964d468fde1dc4aa71a92ea04d930d";
        private const string DestructiveDispel = "d298e64e14398e848a54db5a2619ba42";
        private const string DispelSynergy = "f3e3e29608ba07844ab3cafc4c8e4343";
        private const string SpellFocus = "16fa59cc9a72a6043b566b49184f53fe";
        private const string SpellPenetration = "ee7dc126939e4d9438357fbd5980d459";
        private const string AugmentSummoning = "38155ca9e4055bb48a89240a2055dcc3";
        private const string GreaterSpellPenetration = "1978c3f91cfbbc24b9c9b0d017f4beec";
        private const string SuperiorSummoning = "0477936c0f74841498b5c8753a8062a3";
        private const string WarriorPriest = "b9bee4e4e15573546b76a8d942ce914b";
        private const string DispelFocus = "c39576f8842e4505b14aa918b3a36a0a";
        private const string GreaterDispelFocus = "d0cf79c8e0a44325b00dc8fa6ad37d7c";
        private const string SpellSpecializationFirst = "f327a765a4353d04f872482ef3e48c35";

        // --- Families (0..N) ---
        private const string GreaterElementalFocusSelection = "1c17446a3eb744f438488711b792ca4d";
        private const string ElementalFocusSelection_0 = "bb24cc01319528849b09a3ae8eec0b31";
        private const string SpellFocusGreater = "5b04b45b228461c43bad768eb0f7c7bf";


        private static readonly string[] MemberGuids =
        {
            AmbuscadingSpell,
            ArcaneSpiritFeat,
            CombatCasting,
            DestructiveDispel,
            DispelSynergy,
            SpellFocus,
            SpellPenetration,
            AugmentSummoning,
            GreaterSpellPenetration,
            SuperiorSummoning,
            WarriorPriest,
            DispelFocus,
            GreaterDispelFocus,
            SpellSpecializationFirst
        };

        private static readonly string[] FamilyGuids =
        {
            GreaterElementalFocusSelection,
            ElementalFocusSelection_0,
            SpellFocusGreater
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
