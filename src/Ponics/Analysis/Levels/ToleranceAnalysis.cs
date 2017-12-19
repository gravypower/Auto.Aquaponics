namespace Ponics.Analysis.Levels
{
    public abstract class ToleranceAnalysis<TTolerance> where TTolerance: Tolerance
    {
        public bool SutablalForOrganism { get; set; }
        public bool IdealForOrganism { get; set; }
        public TTolerance Tolerance { get; set; }
    }
}
