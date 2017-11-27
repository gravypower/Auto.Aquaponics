namespace Auto.Aquaponics.Analysis.Levels.Ammonia
{
    public class AmmoniaTolerance : Tolerance
    {
        public AmmoniaTolerance(double lower, double upper, double desiredLower, double desiredUpper) : base(lower, upper, desiredLower, desiredUpper)
        {
        }

        public override Scale Scale => Scale.Ppm;
    }
}
