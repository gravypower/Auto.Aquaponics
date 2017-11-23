using ServiceStack;

namespace Auto.Aquaponics.Analysis.Level.Salinity
{
    [Api("Returns Analysis of Salinity level for an Organism")]
    [Route("/LevelAnalysis/Salinity", "POST")]
    public class SalinityLevelAnalysisQuery : LevelAnalysisQuery<SalinityLevelAnalysis>
    {
    }
}
