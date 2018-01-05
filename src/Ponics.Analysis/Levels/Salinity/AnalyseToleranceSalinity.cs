using Ponics.Organisms.Tolerances;
using ServiceStack;

namespace Ponics.Analysis.Levels.Salinity
{
    [Api("Returns ToleranceAnalysis of Salinity level for an Organism")]
    [Route("/organisms/{OrganismId}/Tolerances/Salinity/{Value}", "GET")]
    [Tag("analysis")]
    public class AnalyseToleranceSalinity : AnalyseToleranceQuery<SalinityLevelAnalysis, SalinityTolerance>
    {
    }
}
