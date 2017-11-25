
using Auto.Aquaponics.Organisms;

namespace Auto.Aquaponics.Tolerances
{
    public class SalinityTolerance : Tolerance
    {
        public SalinityTolerance(double lower, double upper, double desiredLower, double desiredUpper) : base(lower, upper, desiredLower, desiredUpper)
        {
        }

        public override Scale Scale => Scale.Ppm;
    }
}
