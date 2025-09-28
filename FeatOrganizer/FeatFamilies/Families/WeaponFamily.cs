using FeatOrganizer.Features.Families;

namespace FeatOrganizer.FeatFamilies.Families
{
    internal static class WeaponFeatFamily
    {
        // --- Selection meta ---
        private const string SelectionGuid = "d4b7a9c2-5e01-4f83-8ad6-3b0f9e2c7a15";
        private const string SelectionInternal = "FF.WeaponFeats";
        private const string SelectionNameKey = "FF.WeaponFeats.Name";
        private const string SelectionName = "Weapon Feats";
        private const string SelectionDescKey = "FF.WeaponFeats.Desc";
        private const string SelectionDesc = "A collection of weapon feats.";

        // --- Feats (0..N) ---
        private const string TwoWeaponFighting = "ac8aaf29054f5b74eb18f2af950e752d";
        private const string TwoWeaponFightingGreater = "c126adbdf6ddd8245bda33694cd774e8";
        private const string TwoWeaponFightingImproved = "9af88f3ed8a017b45a6837eab7437629";
        private const string DoubleSlice = "8a6a1920019c45d40b4561f05dcb3240";

        // --- Families (0..N) ---
        private const string WeaponFocus = "1e1f627d26ad36f43bbd26cc2bf8ac7e";
        private const string WeaponFocusGreater = "09c9e82965fb4334b984a1e9df3bd088";
        private const string WeaponSpecialization = "31470b17e8446ae4ea0dacd6c5817d86";
        private const string WeaponSpecializationGreater = "7cf5edc65e785a24f9cf93af987d66b3";

        private static readonly string[] MemberGuids =
        {
            TwoWeaponFighting,
            TwoWeaponFightingGreater,
            TwoWeaponFightingImproved,
            DoubleSlice

        };

        private static readonly string[] FamilyGuids =
        {
            WeaponFocus,
            WeaponFocusGreater,
            WeaponSpecialization,
            WeaponSpecializationGreater
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
