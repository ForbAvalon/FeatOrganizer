using System;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Designers.Mechanics.Recommendations;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Class.LevelUp;

namespace FeatOrganizer.Components
{
    /// Agrega recomendaciones de los feats miembros, filtrando por elegibilidad real y excluyendo los ya aprendidos.
    [Serializable]
    public class AggregateMemberRecommendations : LevelUpRecommendationComponent
    {
        public BlueprintFeatureReference[] Members = Array.Empty<BlueprintFeatureReference>();

        public override RecommendationPriority GetPriority(LevelUpState state)
        {
            if (state == null || state.Unit == null || Members == null || Members.Length == 0)
                return RecommendationPriority.Same;

            bool anyEligible = false;
            var best = RecommendationPriority.Same;

            // Bad < Same < Good
            static int Score(RecommendationPriority p) => p switch
            {
                RecommendationPriority.Bad => -1,
                RecommendationPriority.Same => 0,
                RecommendationPriority.Good => 1,
                _ => 0
            };

            var unit = state.Unit;

            foreach (var m in Members)
            {
                var feat = m?.Get();
                if (feat?.ComponentsArray == null) continue;

                // 1) fuera si ya lo tiene
                if (unit.HasFact(feat)) continue;

                // 2) fuera si no cumple prerequisitos ahora
                if (!MeetsPrerequisites(feat, unit, state))
                    continue;

                anyEligible = true;

                // 3) agrega las recomendaciones reales del feat (Good/Same/Bad)
                foreach (var rec in feat.ComponentsArray.OfType<LevelUpRecommendationComponent>())
                {
                    var prio = rec.GetPriority(state);
                    if (Score(prio) > Score(best)) best = prio;
                    if (best == RecommendationPriority.Good) return best; // corto-circuito
                }
            }

            // Si no hay ningún miembro elegible, no recomendamos la carpeta
            return anyEligible ? best : RecommendationPriority.Same;
        }

        private static bool MeetsPrerequisites(BlueprintFeature feat, UnitDescriptor unit, LevelUpState state)
        {
            // Chequeo conservador: si algún Prerequisite falla, no es elegible.
            // Usamos selectionState=null (tu firma lo permite).
            foreach (var pre in feat.ComponentsArray.OfType<Prerequisite>())
            {
                // Aunque el juego oculte algunos en UI (HideInUI), para recomendación nos interesa si bloquea.
                try
                {
                    if (!pre.Check(selectionState: null, unit: unit, state: state))
                        return false;
                }
                catch
                {
                    // Cualquier error evaluando => no lo recomendamos.
                    return false;
                }
            }
            return true;
        }
    }
}
