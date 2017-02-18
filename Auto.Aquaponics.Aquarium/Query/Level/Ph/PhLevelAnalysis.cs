using System.Collections.Generic;

namespace Auto.Aquaponics.Aquarium.Query.Level.Ph
{
    public class PhLevelAnalysis : LevelAnalysis
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
