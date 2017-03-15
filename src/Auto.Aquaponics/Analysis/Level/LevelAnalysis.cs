using Auto.Aquaponics.Kernel.Query;

namespace Auto.Aquaponics.Analysis.Level
{
    public class LevelAnalysis: QueryResult
    {
        public bool? SutablalForOrganism { get; set; }
        public bool? IdealForOrganism { get; set; }
    }
}
