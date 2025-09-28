using FeatOrganizer.Features.Families;

namespace FeatOrganizer.FeatFamilies.Families
{
    internal static class ClassFeatFamily
    {
        // --- Selection meta ---
        private const string SelectionGuid = "9a1f3c7e-2b58-4d9a-8c3e-1f2a6b7c9d0e";
        private const string SelectionInternal = "FF.ClassFeats";
        private const string SelectionNameKey = "FF.ClassFeats.Name";
        private const string SelectionName = "Class Feats";
        private const string SelectionDescKey = "FF.ClassFeats.Desc";
        private const string SelectionDesc = "A collection of class feats.";

        // --- Feats (0..N) ---
        //Paladin
        private const string ExtraLayOnHands = "a2b2f20dfb4d3ed40b9198e22be82030";
        
        //Rage
        private const string RagingBrutality = "c002fad1506842abb2da5bcedacc358e";
        private const string ExtraBloodRage = "7624c6e46551720459cf5292da67d2f9";
        private const string ExtraRage = "1a54bbbafab728348a015cf9ffcf50a7";
        private const string ExtraRageInstinctualWarrior = "dcc338110bab48ddbdc22e82cef7a6db";
        
        //Shape
        private const string ShiftersEdgeFeature = "0e7ec9a341ca46fcaf4d49759e047c83";
        private const string EnergizedWildShapeFeature = "92df031ed2cb4153950853d6a3b9813e";
        private const string ExtendedAspectsFeature = "88e0ca9a742b436ea48ce4845d178c8a";
        private const string FrightfulShape_ = "8e8a34c754d649aa9286fe8ee5cc3f10";
        private const string NaturalSpell = "c806103e27cce6f429e5bf47067966cf";
        private const string RakingClawsFeature = "a1b262d2b1ef478994113fc941fa3a32";
        private const string MultiattackShifter = "b5d998bd85a74b708516e24fa198874e";
        private const string ShiftersRushFeature = "4ddc88f422a84f76a952e24bec7b53e1";
        
        //Alchemist
        private const string BombAbilityFocus = "f864101ab0cdb4b418c7d62d2b24eee5";
        private const string ExtraBombs = "54c57ce67fa1d9044b1b3edc459e05e2";

        //Arcane
        private const string ExtraArcanePool = "42f96fc8d6c80784194262e51b0a1d25";
        private const string ExtraReservoir = "29afc53efa4d469b9476760fa09576de";

        //Inquisitor
        private const string ExtraBane = "756dc2f7340b0b34285a1dc367ff7359";
        private const string SpellBane = "d2d1b1f27bdf4ddfa5bf8b7244786ff9";

        //Channel
        private const string ExtraChannel = "cd9f19775bd9d3343a31a065e93f0c47";
        private const string ExtraChannelEmpyrealSorcerer = "347e8d794c9598e4abed70adda868ccd";
        private const string ExtraChannelHexChanneler = "88f426f13de236642b9585efcb82f1d8";
        private const string ExtraChannelHospitaler = "8d4f82fdb4d09b247ae8cd1ae7ce02de";
        private const string ExtraChannelOracle = "53da6bf487997e947960bd6c02be9adf";
        private const string ExtraChannelShaman = "4cc73e43ab814bc48ade2e291729b359";
        private const string SelectiveChannel = "fd30c69417b434d47b6b03b9c1f568ff";

        //Hex
        private const string ExtraShamanHexSelection = "d0b4c8245d504b8c9c6d3fccc1f8c5b6";
        private const string ExtraWitchHexSelection = "b6054088b4ab4be286724127cbf48b35";

        //Monk
        private const string ExtraKi = "231a2a603d0b437e939553e6da3e7247";

        //Performance
        private const string ExtraPerformance = "0d3651b2cb0d89448b112e23214e744e";
        private const string ExtraPerformancePaladinMartyr = "639ce2b85a13404caa618f36748d7fa5";
        private const string ExtraPerformanceSkald = "15c78493a0ce471cb279e6363d702cc8";
        private const string LingeringPerformance = "17239b298065efc459cffe2220ecb559";
        private const string DiscordantVoice = "49a72b24ad604be481ad73994e14a34b";

        //FavoredEnemy
        private const string FavoredEnemySpellcasting = "0226d84afe68462da8a392798f1225b8";

        //Bard
        private const string HarmonicSpell = "88c5ed03321d45b99a65a621c5963c65";

        //Copmpanion
        private const string CompanionBoon = "8fc01f06eab4dd946baa5bc658cac556";


        // --- Families (0..N) ---
        //Paladin
        private const string ExtraMercySelection = "8a49abed5be9473da1e1fd1e2457562e";
        
        //Rage
        private const string ExtraRagePowerSelection = "0c7f01fbbe687bb4baff8195cb02fe6a";

        //Magus
        private const string ExtraArcanaSelection = "00727883edf145e2a6bce9ad176ecfd8";

        //Arcanist
        private const string ExtraArcanistExploitSelection = "0a7065e13f4449fa81bfb33199bf7f6a";

        //Alchemist
        private const string ExtraDiscoverySelection = "537965879fc24ad3948aaffa7a1a3a66";
        private const string ExtraVivsectionistDiscoverySelection = "10287e7b8cee479e82ea88bd6d2d4dae";

        //ExtraTalent
        private const string ExtraRogueTalentSelection = "14d9089df87a43b696fa9451ca2f0a12";
        private const string ExtraSlayerTalentSelection = "53f7237f5b1447bb851ba68045a00e41";
        private const string ExtraWildTalentSelection = "0f73730cf1b44ee882671e55d5f6e471";



        private static readonly string[] MemberGuids =
        {
            ExtraLayOnHands,
            RagingBrutality,
            ExtraBloodRage,
            ExtraRage,
            ExtraRageInstinctualWarrior,
            ShiftersEdgeFeature,
            EnergizedWildShapeFeature,
            ExtendedAspectsFeature,
            FrightfulShape_,
            NaturalSpell,
            RakingClawsFeature,
            MultiattackShifter,
            ShiftersRushFeature,
            BombAbilityFocus,
            ExtraBombs,
            ExtraArcanePool,
            ExtraReservoir,
            SpellBane,
            ExtraChannel,
            ExtraChannelEmpyrealSorcerer,
            ExtraChannelHexChanneler,
            ExtraChannelHospitaler,
            ExtraChannelOracle,
            ExtraChannelShaman,
            SelectiveChannel,
            ExtraShamanHexSelection,
            ExtraWitchHexSelection,
            ExtraKi,
            ExtraPerformance,
            ExtraPerformancePaladinMartyr,
            ExtraPerformanceSkald,
            LingeringPerformance,
            FavoredEnemySpellcasting,
            HarmonicSpell,
            CompanionBoon,
            ExtraBane,
            DiscordantVoice
        };

        private static readonly string[] FamilyGuids =
        {
            ExtraMercySelection,
            ExtraRagePowerSelection,
            ExtraArcanaSelection,
            ExtraArcanistExploitSelection,
            ExtraDiscoverySelection,
            ExtraVivsectionistDiscoverySelection,
            ExtraSlayerTalentSelection,
            ExtraWildTalentSelection,
            ExtraRogueTalentSelection
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
