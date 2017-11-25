using Auto.Aquaponics.Organisms;

namespace Auto.Aquaponics.Tolerances
{
    public class AmmoniaTolerance : Tolerance
    {
        public AmmoniaTolerance(double lower, double upper, double desiredLower, double desiredUpper) : base(lower, upper, desiredLower, desiredUpper)
        {
        }

        public override Scale Scale => Scale.Ppm;
    }
}
