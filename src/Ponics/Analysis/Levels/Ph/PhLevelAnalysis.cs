using System.Collections.Generic;

namespace Ponics.Analysis.Levels.Ph
{
    public class PhLevelAnalysis : LevelAnalysis<PhTolerance>
    {
        public double HydrogenIonConcentration   { get; set; }
        public double HydroxideIonsConcentration { get; set; }
        public List<string> Warnings { get; set; }

        public PhLevelAnalysis()
        {
            Warnings = new List<string>();
        }
    }
}
