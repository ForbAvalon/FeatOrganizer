using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.UnitLogic.Mechanics.Components;

namespace FeatOrganizer.FeatFamilies.Families
{
    internal static class ShieldFeatFamily
    {
        // --- Selection meta ---
        private const string SelectionGuid = "c3a7e5f1-2b9d-4d0a-8f3e-7c1d5a9b2468";
        private const string SelectionInternal = "FF.ShieldFeats";
        private const string SelectionNameKey = "FF.ShieldFeats.Name";
        private const string SelectionName = " Shield Feats";
        private const string SelectionDescKey = "FF.ShieldFeats.Desc";
        private const string SelectionDesc = "A collection of shield feats.";

        // --- Feats (0..N) ---
        private const string ShieldFocus = "ac57069b6bf8c904086171683992a92a";
        private const string ShieldBashFeature = "121811173a614534e8720d7550aae253";
        private const string MissileShield = "5ffcd225924514348ac71730179b5b24";
        private const string RayShield = "e92cb7c4c900dcf4282def347af42b9c";
        private const string BashingFinish = "0b442a7b4aa598d4e912a4ecee0500ff";
        private const string ShieldFocusGreater = "afd05ca5363036c44817c071189b67e1";
        private const string ShieldMaster = "dbec636d84482944f87435bd31522fcc";
        private const string StumblingBash = "1fc8c07a82d749a1a35b6992ad359788";
        private const string TopplingBash = "cc198d726ac34b4599bd1b4d22a7f2b7";


        // --- Families (0..N) ---
        

        private static readonly string[] MemberGuids =
        {
            ShieldFocus,
            ShieldBashFeature,
            MissileShield,
            RayShield,
            BashingFinish,
            ShieldFocusGreater,
            ShieldMaster,
            StumblingBash,
            TopplingBash
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
