using ServiceStack;

namespace Auto.Aquaponics.Analysis.Level.Ph
{
    [Api("Returns Analysis of Ph level for an Organism")]
    [Route("/LevelAnalysis/Ph", "POST")]
    public class PhLevelAnalysisQuery : LevelAnalysisQuery<PhLevelAnalysis>
    {
        public PhLevelAnalysisQuery(double value) : base(value)
        {
        }
    }
}
