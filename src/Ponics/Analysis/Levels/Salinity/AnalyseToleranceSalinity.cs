using ServiceStack;

namespace Ponics.Analysis.Levels.Salinity
{
    [Api("Returns ToleranceAnalysis of Salinity level for an Organism")]
    [Route("/organisms/{OrganismId}/Tolerances/Salinity/{Value}", "GET")]
    public class AnalyseToleranceSalinity : AnalyseToleranceQuery<SalinityToleranceAnalysis, SalinityTolerance>
    {
    }
}
