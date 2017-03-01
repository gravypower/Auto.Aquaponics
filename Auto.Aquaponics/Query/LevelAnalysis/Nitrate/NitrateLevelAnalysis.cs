namespace Auto.Aquaponics.Query.LevelAnalysis.Nitrate
{
    public class NitrateLevelAnalysis : LevelAnalysisQuery
    {
        public NitrateLevelAnalysis()
        {
        }

        public NitrateLevelAnalysis(Organisms.Organism organism) : base(organism)
        {
        }

        public NitrateLevelAnalysis(double value, Organisms.Organism organism) : base(value, organism)
        {
        }
    }
}
