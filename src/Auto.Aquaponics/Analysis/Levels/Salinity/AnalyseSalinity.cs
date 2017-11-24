using ServiceStack;

namespace Auto.Aquaponics.Analysis.Levels.Salinity
{
    [Api("Returns Analysis of Salinity level for an Organism")]
    [Route("/Analysis/Salinity", "POST")]
    public class AnalyseSalinity : AnalyseQuery<SalinityAnalysis>
    {
    }
}
