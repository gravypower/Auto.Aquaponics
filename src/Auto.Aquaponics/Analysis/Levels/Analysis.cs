namespace Auto.Aquaponics.Analysis.Levels
{
    public abstract class Analysis<TTolerance> where TTolerance: Tolerance
    {
        public bool SutablalForOrganism { get; set; }
        public bool IdealForOrganism { get; set; }
        public TTolerance Tolerance { get; set; }
    }
}
