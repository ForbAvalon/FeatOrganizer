namespace FeatOrganizer.FeatFamilies.Families
{
    internal static class CriticalFeatFamily
    {
        // --- Selection meta ---
        private const string SelectionGuid = "a2d7f9c4-3b1e-4f6a-9d28-73c1e5b4a9f0";
        private const string SelectionInternal = "FF.CriticalFeats";
        private const string SelectionNameKey = "FF.CriticalFeats.Name";
        private const string SelectionName = "Critical Feats";
        private const string SelectionDescKey = "FF.CriticalFeats.Desc";
        private const string SelectionDesc = "A collection of critical feats.";

        // --- Feats (0..N) ---
        private const string CriticalMastery = "fc85925cd241dd0408ab2f4cb171b7e3";
        private const string BleedingCriticalFeature = "42be7d465db94213baf0578c721803ff";
        private const string BlindingCriticalFeature = "787e56055e3ef864d9c78a3ec21e56be";
        private const string CriticalFocus = "8ac59959b1b23c347a0361dc97cc786d";
        private const string ExhaustingCriticalFeature = "7c492212d25d8f04fbd43eb99d780b1e";
        private const string FlayingCriticalFeature = "a0e95a17fed549bcbf85a977811f6094";
        private const string SickeningCriticalFeature = "4c7205d859a1e114895e798af383d76a";
        private const string StaggeringCriticalFeature = "055fb8dcaf6be334ca13172bafa9e782";
        private const string StunningCriticalFeature = "7fb3023bda2f42728e76cf269f5a2fa0";
        private const string TiringCriticalFeature = "12c1b556df3b667458ae200bfb38ccb8";

        // --- Families (0..N) ---
        private const string ImprovedCritical = "f4201c85a991369408740c6888362e20";

        private static readonly string[] MemberGuids =
        {
            CriticalMastery,
            BleedingCriticalFeature,
            BlindingCriticalFeature,
            CriticalFocus,
            ExhaustingCriticalFeature,
            FlayingCriticalFeature,
            SickeningCriticalFeature,
            StaggeringCriticalFeature,
            StunningCriticalFeature,
            TiringCriticalFeature
        };

        private static readonly string[] FamilyGuids =
        {
            ImprovedCritical
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
