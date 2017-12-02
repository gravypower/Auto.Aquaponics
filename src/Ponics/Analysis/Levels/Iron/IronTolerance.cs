using ServiceStack;

namespace Ponics.Analysis.Levels.Iron
{
    public class IronTolerance: Tolerance
    {
        public IronTolerance(double lower, double upper, double desiredLower, double desiredUpper) : base(lower, upper, desiredLower, desiredUpper)
        {
        }

        [ApiMember(ExcludeInSchema = true)]
        public override Scale Scale => Scale.Ppm;
    }
}
