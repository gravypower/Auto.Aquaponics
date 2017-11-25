using Auto.Aquaponics.Organisms;
using Auto.Aquaponics.Tolerances;

namespace Auto.Aquaponics.Analysis.Levels
{
    public class Analysis
    {
        public bool SutablalForOrganism { get; set; }
        public bool IdealForOrganism { get; set; }
        public Tolerance Tolerance { get; set; }
    }
}
