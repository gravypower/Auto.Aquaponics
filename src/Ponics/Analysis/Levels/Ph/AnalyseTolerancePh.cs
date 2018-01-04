using ServiceStack;

namespace Ponics.Analysis.Levels.Ph
{
    [Api("Returns ToleranceAnalysis of pH level for an Organism")]
    [Route("/organisms/{OrganismId}/Tolerances/Ph/{Value}", "GET")]
    [Tag("analysis")]
    public class AnalyseTolerancePh : AnalyseToleranceQuery<PhLevelAnalysis, PhTolerance>
    {
    }
}
