using System.Collections.Generic;

namespace Auto.Aquaponics.Query.LevelAnalysis.Ph
{
    public class PhLevelAnalysisResult : LevelAnalysisResult
    {
        public double HydrogenIonConcentration   { get; set; }
        public double HydroxideIonsConcentration { get; set; }
        public List<string> Warnings { get; set; }

        public PhLevelAnalysisResult()
        {
            Warnings = new List<string>();
        }
    }
}
