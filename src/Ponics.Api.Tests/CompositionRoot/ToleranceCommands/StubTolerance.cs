using Ponics.Analysis.Levels;
using Ponics.Organisms.Tolerances;

namespace Ponics.Api.Tests.CompositionRoot.ToleranceCommands
{
    public class StubTolerance:Tolerance
    {
        public StubTolerance(double lower, double upper, double desiredLower, double desiredUpper) : base(lower, upper, desiredLower, desiredUpper)
        {
        }

        public override Scale Scale { get; }
    }
}
