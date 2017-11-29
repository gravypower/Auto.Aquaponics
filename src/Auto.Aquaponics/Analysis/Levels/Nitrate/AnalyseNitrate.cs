using ServiceStack;

namespace Auto.Aquaponics.Analysis.Levels.Nitrate
{
    [Api("Returns Analysis of Nitrate levels for an Organism")]
    [Route("/organisms/{OrganismId}/Tolerances/Nitrite/{Value}", "GET")]
    public class AnalyseNitrate : AnalyseQuery<NitrateAnalysis, NitrateTolerance>
    {
    }
}
