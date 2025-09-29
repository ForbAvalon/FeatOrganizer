using FeatOrganizer.FeatFamilies.Families;
using FeatOrganizer.Features.Families;
using FeatOrganizer.Utils;
using HarmonyLib;
using Kingmaker.Blueprints.JsonSystem;

namespace FeatOrganizer.Patches
{
    [HarmonyPatch(typeof(BlueprintsCache), "Init")]
    internal static class BlueprintsCache_Init_Patch
    {
        private static bool _done;

        static void Postfix()
        {
            if (_done) return;
            _done = true;

            try
            {
                Log.Info("[CO][Init] Applying FeatFamilies...");
                RangedFeatFamily.Configure();
                WeaponFeatFamily.Configure();
                FeintFeatFamily.Configure();
                MeleeFeatFamily.Configure();
                SkillFeatFamily.Configure();
                TeamworkFeatFamily.Configure();
                MagicFeatFamily.Configure();
                DefenseFeatFamily.Configure();
                UnarmedFeatFamily.Configure();
                MetamagicFeatFamily.Configure();
                MountedFeatFamily.Configure();
                ShieldFeatFamily.Configure();
                ProficiencyFeatFamily.Configure();
                AttackFeatFamily.Configure();
                CriticalFeatFamily.Configure();
                ManeuverFeatFamily.Configure();
                RaceFeatFamily.Configure();
                ClassFeatFamily.Configure();
                Log.Info("[CO][Init] FeatFamilies applied.");
            }
            catch (System.Exception ex)
            {
                Log.Error("[CO][Init] Error applying FeatFamily", ex);
            }
        }
    }
}
