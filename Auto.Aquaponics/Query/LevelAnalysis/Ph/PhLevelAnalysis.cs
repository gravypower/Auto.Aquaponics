namespace Auto.Aquaponics.Query.LevelAnalysis.Ph
{
    public class PhLevelAnalysis : LevelAnalysisQuery
    {
        public PhLevelAnalysis()
        {
        }

        public PhLevelAnalysis(Organisms.Organism organism) : base(organism)
        {
        }

        public PhLevelAnalysis(double value, Organisms.Organism organism) : base(value, organism)
        {
        }
    }
}
