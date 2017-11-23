using ServiceStack;

namespace Auto.Aquaponics.Analysis.Level.Nitrate
{
    [Api("Returns Analysis of Nitrate level for an Organism")]
    [Route("/LevelAnalysis/Nitrate", "POST")]
    public class NitrateLevelAnalysisQuery : LevelAnalysisQuery<NitrateLevelAnalysis>
    {
        public NitrateLevelAnalysisQuery(double value) : base(value)
        {
        }
    }
}
