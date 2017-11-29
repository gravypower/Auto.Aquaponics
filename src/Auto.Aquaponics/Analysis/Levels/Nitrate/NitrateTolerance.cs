using ServiceStack;

namespace Auto.Aquaponics.Analysis.Levels.Nitrate
{
    public class NitrateTolerance:Tolerance
    {
        public NitrateTolerance(double lower, double upper, double desiredLower, double desiredUpper) : base(lower, upper, desiredLower, desiredUpper)
        {
        }

        [ApiMember(ExcludeInSchema = true)]
        public override Scale Scale => Scale.Ppm;
    }
}
