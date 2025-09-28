using FeatOrganizer.FeatFamilies;
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
                Log.Info("[CO][Init] Applying RangedFeatFamily...");
                RangedFeatFamily.Configure();
                MeleeFeatFamily.Configure();
                SkillFeatFamily.Configure();
                Log.Info("[CO][Init] RangedFeatFamily applied.");
            }
            catch (System.Exception ex)
            {
                Log.Error("[CO][Init] Error applying RangedFeatFamily", ex);
            }
        }
    }
}
