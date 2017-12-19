using ServiceStack;

namespace Ponics.Analysis.Levels.Iron
{
    [Api("Returns ToleranceAnalysis of Iron  levels for an Organism")]
    [Route("/organisms/{OrganismId}/Tolerances/Iron/{Value}", "GET")]
    public class AnalyseToleranceIron : AnalyseToleranceQuery<IronToleranceAnalysis, IronTolerance>
    {
    }
}
