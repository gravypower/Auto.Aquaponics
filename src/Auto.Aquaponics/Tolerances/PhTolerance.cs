using Auto.Aquaponics.Organisms;

namespace Auto.Aquaponics.Tolerances
{
    public class PhTolerance: Tolerance
    {
        public PhTolerance(double lower, double upper, double desiredLower, double desiredUpper) : base(lower, upper, desiredLower, desiredUpper)
        {
        }

        public override Scale Scale => Scale.Ph;
    }
}
