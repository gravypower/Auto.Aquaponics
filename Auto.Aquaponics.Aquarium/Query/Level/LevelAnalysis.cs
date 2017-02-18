using Auto.Aquaponics.Kernel.Query;

namespace Auto.Aquaponics.Aquarium.Query.Level
{
    public class LevelAnalysis: QueryResult
    {
        public bool? SutablalForOrganism { get; set; }
        public bool? IdealForOrganism { get; set; }
    }
}
