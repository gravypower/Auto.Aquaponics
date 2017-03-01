namespace Auto.Aquaponics.Query.LevelAnalysis.Salinity
{
    public class SalinityLevelAnalysis : LevelAnalysisQuery
    {
        public SalinityLevelAnalysis()
        {
        }

        public SalinityLevelAnalysis(Organisms.Organism organism) : base(organism)
        {
        }

        public SalinityLevelAnalysis(double value, Organisms.Organism organism) : base(value, organism)
        {
        }
    }
}
