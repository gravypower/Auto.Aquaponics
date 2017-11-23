using ServiceStack;

namespace Auto.Aquaponics.Analysis.Level.Ammonia
{
    [Api("Returns Analysis of Ammonia level for an Organism")]
    [Route("/LevelAnalysis/Ammonia", "POST")]
    public class AmmoniaLevelAnalysisQuery : LevelAnalysisQuery<AmmoniaLevelAnalysis>
    {
        public AmmoniaLevelAnalysisQuery(double value) : base(value)
        {
        }
    }
}
