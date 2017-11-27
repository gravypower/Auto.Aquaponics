namespace Auto.Aquaponics.Analysis.Levels.Iron
{
    public class IronTolerance: Tolerance
    {
        public IronTolerance(double lower, double upper, double desiredLower, double desiredUpper) : base(lower, upper, desiredLower, desiredUpper)
        {
        }

        public override Scale Scale => Scale.Ppm;
    }
}
