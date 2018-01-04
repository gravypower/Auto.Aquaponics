namespace Ponics.Analysis.Levels
{
    public abstract class LevelAnalysis<TTolerance>: LevelAnalysis where TTolerance: Tolerance
    {
        public TTolerance Tolerance { get; set; }
    }

    public abstract class LevelAnalysis
    {
        public bool SuitableForOrganism { get; set; }
        public bool IdealForOrganism { get; set; }
    }
}
