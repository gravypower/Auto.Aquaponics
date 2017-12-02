using ServiceStack;

namespace Ponics.Analysis.Levels.Iron
{
    [Api("Returns Analysis of Iron  levels for an Organism")]
    [Route("/organisms/{OrganismId}/Tolerances/Iron/{Value}", "GET")]
    public class AnalyseIron : AnalyseQuery<IronAnalysis, IronTolerance>
    {
    }
}
