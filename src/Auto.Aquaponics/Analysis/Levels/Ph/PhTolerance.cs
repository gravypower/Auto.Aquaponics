using ServiceStack;

namespace Auto.Aquaponics.Analysis.Levels.Ph
{
    public class PhTolerance: Tolerance
    {
        public PhTolerance(double lower, double upper, double desiredLower, double desiredUpper) : base(lower, upper, desiredLower, desiredUpper)
        {
        }

        [ApiMember(ExcludeInSchema = true)]
        public override Scale Scale => Scale.Ph;
    }
}
