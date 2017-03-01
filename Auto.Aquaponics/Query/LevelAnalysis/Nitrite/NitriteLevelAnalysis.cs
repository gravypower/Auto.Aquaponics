namespace Auto.Aquaponics.Query.LevelAnalysis.Nitrite
{
    public class NitriteLevelAnalysis : LevelAnalysisQuery
    {
        public NitriteLevelAnalysis()
        {
        }

        public NitriteLevelAnalysis(Organisms.Organism organism) : base(organism)
        {
        }

        public NitriteLevelAnalysis(double value, Organisms.Organism organism) : base(value, organism)
        {
        }
    }
}
