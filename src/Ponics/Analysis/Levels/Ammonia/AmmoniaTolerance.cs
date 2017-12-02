using ServiceStack;

namespace Ponics.Analysis.Levels.Ammonia
{
    public class AmmoniaTolerance : Tolerance
    {
        public AmmoniaTolerance(double lower, double upper, double desiredLower, double desiredUpper) : base(lower, upper, desiredLower, desiredUpper)
        {
        }

        [ApiMember(ExcludeInSchema = true)]
        public override Scale Scale => Scale.Ppm;
    }
}
