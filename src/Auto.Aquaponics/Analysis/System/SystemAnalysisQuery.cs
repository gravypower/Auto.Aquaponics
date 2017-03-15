using Auto.Aquaponics.Analysis.Level;
using Auto.Aquaponics.Kernel.Query;

namespace Auto.Aquaponics.Analysis.System
{
    public class SystemAnalysisQuery : Query<SystemAnalysis>
    {
        public AquaponicSystem System { get; }
        public LevelAnalysisQuery<LevelAnalysis> LevelAnalysisQuery { get; }

        public SystemAnalysisQuery(AquaponicSystem system, LevelAnalysisQuery<LevelAnalysis> levelAnalysisQuery)
        {
            System = system;
            LevelAnalysisQuery = levelAnalysisQuery;
        }
    }
}
