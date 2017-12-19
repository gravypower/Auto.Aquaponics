using Ponics.Analysis.Levels;

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
