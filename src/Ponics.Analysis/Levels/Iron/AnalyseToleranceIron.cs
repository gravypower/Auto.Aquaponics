using Ponics.Organisms.Tolerances;
using ServiceStack;

namespace Ponics.Analysis.Levels.Iron
{
    [Api("Returns ToleranceAnalysis of Iron  levels for an Organism")]
    [Route("/organisms/{OrganismId}/Tolerances/Iron/{Value}", "GET")]
    [Tag("analysis")]
    public class AnalyseToleranceIron : AnalyseToleranceQuery<IronLevelAnalysis, IronTolerance>
    {
    }
}
