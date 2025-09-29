namespace FeatOrganizer.FeatFamilies.Families
{
    internal static class MetamagicFeatFamily
    {
        // --- Selection meta ---
        private const string SelectionGuid = "f6a3c8d2-41e7-4b9a-8c25-9d1e3b7a2c54";
        private const string SelectionInternal = "FF.MetamagicFeats";
        private const string SelectionNameKey = "FF.MetamagicFeats.Name";
        private const string SelectionName = "Metamagic Feats";
        private const string SelectionDescKey = "FF.MetamagicFeats.Desc";
        private const string SelectionDesc = "A collection of metamagic feats.";

        // --- Feats (0..N) ---
        private const string BolsteredSpellFeat = "fbf5d9ce931f47f3a0c818b3f8ef8414";
        private const string EmpowerSpellFeat = "a1de1e4f92195b442adb946f0e2b9d4e";
        private const string ExtendSpellFeat = "f180e72e4a9cbaa4da8be9bc958132ef";
        private const string HeightenSpellFeat = "2f5d1e705c7967546b72ad8218ccf99c";
        private const string IntensifiedSpell = "8ad7fd39abea4722b39eb5a67d606a41";
        private const string MaximizeSpellFeat = "7f2b282626862e345935bbea5e66424b";
        private const string PersistentSpellFeat = "cd26b9fa3f734461a0fcedc81cafaaac";
        private const string PiercingSpell = "c101ad6879a94204a780506f7a554865";
        private const string QuickenSpellFeat = "ef7ece7bb5bb66a41b256976b27f424e";
        private const string ReachSpellFeat = "46fad72f54a33dc4692d3b62eca7bb78";
        private const string SelectiveSpellFeat = "85f3340093d144dd944fff9a9adfd2f2";
        private const string CompletelyNormalSpellFeat = "094b6278f7b570f42aeaa98379f07cf2";

        // --- Families (0..N) ---


        private static readonly string[] MemberGuids =
        {
            BolsteredSpellFeat,
            EmpowerSpellFeat,
            ExtendSpellFeat,
            HeightenSpellFeat,
            IntensifiedSpell,
            MaximizeSpellFeat,
            PersistentSpellFeat,
            PiercingSpell,
            QuickenSpellFeat,
            ReachSpellFeat,
            SelectiveSpellFeat,
            CompletelyNormalSpellFeat
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
