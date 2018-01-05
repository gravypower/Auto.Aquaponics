using Ponics.Organisms.Tolerances;
using ServiceStack;

namespace Ponics.Analysis.Levels.Nitrate
{
    [Api("Returns Analysis of Nitrate levels for an Organism")]
    [Route("/organisms/{OrganismId}/Tolerances/Nitrite/{Value}", "GET")]
    [Tag("analysis")]
    public class AnalyseToleranceNitrate : AnalyseToleranceQuery<NitrateLevelAnalysis, NitrateTolerance>
    {
    }
}
