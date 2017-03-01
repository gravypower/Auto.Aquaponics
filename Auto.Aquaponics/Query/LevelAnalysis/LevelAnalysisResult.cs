using Auto.Aquaponics.Kernel.Query;

namespace Auto.Aquaponics.Query.LevelAnalysis
{
    public class LevelAnalysisResult: QueryResult
    {
        public bool? SutablalForOrganism { get; set; }
        public bool? IdealForOrganism { get; set; }
    }
}
