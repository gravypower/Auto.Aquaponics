using ServiceStack;

namespace Ponics.Analysis.Levels.Nitrite
{
    [Api("Returns ToleranceAnalysis of Nitrite levels for an Organism")]
    [Route("/organisms/{OrganismId}/Tolerances/Nitrite/{Value}", "GET")]
    [Tag("analysis")]
    public class AnalyseToleranceNitrite : AnalyseToleranceQuery<NitriteLevelAnalysis, NitriteTolerance>
    {
    }
}
