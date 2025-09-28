using FeatOrganizer.Features.Families; // para FamilyBuilder

namespace FeatOrganizer.FeatFamilies.Families
{
    internal static class MeleeFeatFamily
    {
        // --- Selection meta ---
        private const string SelectionGuid = "f2a1c3d4-7b89-4e2f-9a5b-3c1d2e4f6a78";
        private const string SelectionInternal = "FF.MeleeFeat";
        private const string SelectionNameKey = "FF.MeleeFeat.Name";
        private const string SelectionName = "Melee Feats";
        private const string SelectionDescKey = "FF.MeleeFeat.Desc";
        private const string SelectionDesc = "A collection of melee combat feats.";

        // --- Feats (0..N) ---
        private const string PowerAttackFeature = "9972f33f977fc724c838e59641b2fca5";
        private const string WeaponFinesse = "90e54424d682d104ab36436bd527af09";
        private const string CombatReflexes = "0f8939ae6f220984e8fb568abbdfba95";
        private const string CleavingFinish = "59bd93899149fa44687ff4121389b3a9";
        private const string ImprovedCleavingFinish = "ffa1b373190af4f4db7a5501904a1983";
        private const string PiranhaStrikeFeature = "6a556375036ac8b4ebd80e74d308d108";
        private const string CleaveFeature = "d809b6c4ff2aaff4fa70d712a70f7d7b";
        private const string FuriousFocus = "f09b89812cc94b89a09069671002b899";
        private const string GreatCleaveFeature = "cc9c862ef2e03af4f89be5088851ea35";
        private const string VitalStrikeFeatureGreater = "e2d1fa11f6b095e4fb2fd1dcf5e36eb3";
        private const string VitalStrikeFeatureImproved = "52913092cd018da47845f36e6fbe240f";
        private const string LungeFeature = "d41d5bd9a775d7245929256d58a3e03e";
        private const string RagingBrutality = "c002fad1506842abb2da5bcedacc358e";
        private const string VitalStrikeFeature = "14a1fc1356df9f146900e1e42142fc9d";

        // --- Familias anidadas (0..N) ---
        private const string FencingGrace = "47b352ea0f73c354aba777945760b441";
        private const string SlashingGrace = "697d64669eb2c0543abb9c9b07998a38";

        private static readonly string[] MemberGuids =
        {
            PowerAttackFeature, WeaponFinesse, CombatReflexes, CleavingFinish,
            ImprovedCleavingFinish, PiranhaStrikeFeature, CleaveFeature, FuriousFocus,
            GreatCleaveFeature, VitalStrikeFeatureGreater, VitalStrikeFeatureImproved,
            LungeFeature, RagingBrutality, VitalStrikeFeature
        };

        private static readonly string[] FamilyGuids =
        {
            FencingGrace, SlashingGrace
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
