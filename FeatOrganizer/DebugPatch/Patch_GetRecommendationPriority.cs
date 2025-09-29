/*using FeatOrganizer.Utils;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Recommendations;
using Kingmaker.UnitLogic.Class.LevelUp;
using System;
using System.Linq;

namespace FeatOrganizer.DebugPatch
{
    [HarmonyPatch(typeof(LevelUpRecommendationEx), nameof(LevelUpRecommendationEx.GetRecommendationPriority),
                  new Type[] { typeof(BlueprintScriptableObject), typeof(LevelUpState), typeof(FeatureParam) })]
    static class Patch_GetRecommendationPriority
    {
        static void Postfix(BlueprintScriptableObject blueprint, LevelUpState levelUpState, FeatureParam param, ref int __result)
        {
            if (blueprint == null || levelUpState == null) return;
            // 1) Log del resultado final que verá la UI
            Log.Info($"[FO][CoreRec] BP={blueprint.name}  Final={__result}");

            // 2) Log por componente (duplica la lógica del engine para entender el porqué)
            try
            {
                var comps = blueprint.ComponentsArray?.OfType<LevelUpRecommendationComponent>()?.ToArray();
                if (comps == null || comps.Length == 0) return;

                foreach (var c in comps)
                {
                    RecommendationPriority p = RecommendationPriority.Same;
                    try { p = c.GetPriority(levelUpState); }
                    catch (Exception ex) { Log.Info($"[FO][CoreRec]   {c.GetType().Name} EX: {ex.Message}"); }

                    Log.Info($"[FO][CoreRec]   {c.GetType().Name} -> {p}");
                }
            }
            catch {  }
        }
    }

    // Si usas parametrizados, parchea también:
    // static class Patch_GetParametrizedRecommendationPriority { ... } análogo
}*/
