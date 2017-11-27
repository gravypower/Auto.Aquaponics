namespace Auto.Aquaponics.Analysis.Levels.Nitrite
{
    public class NitriteTolerance:Tolerance
    {
        public NitriteTolerance(double lower, double upper, double desiredLower, double desiredUpper) : base(lower, upper, desiredLower, desiredUpper)
        {
        }

        public override Scale Scale => Scale.Ppm;
    }
}
