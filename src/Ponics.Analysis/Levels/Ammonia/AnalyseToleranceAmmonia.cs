using Ponics.Organisms.Tolerances;
using ServiceStack;

namespace Ponics.Analysis.Levels.Ammonia
{
    [Api("Returns Analysis of Ammonia levels for an Organism")]
    [Route("/organisms/{OrganismId}/Tolerances/Ammonia/{Value}", "GET")]
    [Tag("analysis")]
    public class AnalyseToleranceAmmonia : AnalyseToleranceQuery<AmmoniaLevelAnalysis, AmmoniaTolerance>
    {
    }
}
