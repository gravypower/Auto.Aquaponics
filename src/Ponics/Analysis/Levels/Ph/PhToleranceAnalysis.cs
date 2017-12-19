using System.Collections.Generic;

namespace Ponics.Analysis.Levels.Ph
{
    public class PhToleranceAnalysis : ToleranceAnalysis<PhTolerance>
    {
        public double HydrogenIonConcentration   { get; set; }
        public double HydroxideIonsConcentration { get; set; }
        public List<string> Warnings { get; set; }

        public PhToleranceAnalysis()
        {
            Warnings = new List<string>();
        }
    }
}
