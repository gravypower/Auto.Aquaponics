using ServiceStack;

namespace Ponics.Organisms.Tolerances
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
