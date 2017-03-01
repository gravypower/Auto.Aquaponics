namespace Auto.Aquaponics.Query.LevelAnalysis.Ammonia
{
    public class AmmoniaLevelAnalysis : LevelAnalysisQuery
    {
        public AmmoniaLevelAnalysis()
        {
        }

        public AmmoniaLevelAnalysis(Organisms.Organism organism) : base(organism)
        {
        }

        public AmmoniaLevelAnalysis(double value, Organisms.Organism organism) : base(value, organism)
        {
        }
    }
}
