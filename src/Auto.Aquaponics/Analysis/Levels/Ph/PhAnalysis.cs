using System.Collections.Generic;

namespace Auto.Aquaponics.Analysis.Levels.Ph
{
    public class PhAnalysis : Analysis
    {
        public double HydrogenIonConcentration   { get; set; }
        public double HydroxideIonsConcentration { get; set; }
        public List<string> Warnings { get; set; }

        public PhAnalysis()
        {
            Warnings = new List<string>();
        }
    }
}
