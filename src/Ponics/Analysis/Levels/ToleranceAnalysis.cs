namespace Ponics.Analysis.Levels
{
    public abstract class ToleranceAnalysis<TTolerance>: ToleranceAnalysis where TTolerance: Tolerance
    {
        public TTolerance Tolerance { get; set; }
    }

    public abstract class ToleranceAnalysis
    {
        public bool SuitableForOrganism { get; set; }
        public bool IdealForOrganism { get; set; }
    }
}
