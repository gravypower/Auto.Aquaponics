using ServiceStack;

namespace Auto.Aquaponics.Analysis.Levels.Salinity
{
    [Api("Returns Analysis of Salinity level for an Organism")]
    [Route("/Analysis/Salinity", "GET,POST")]
    public class AnalyseSalinity : AnalyseQuery<SalinityAnalysis, SalinityTolerance>
    {
    }
}
