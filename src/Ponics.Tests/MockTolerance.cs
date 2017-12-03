using Ponics.Analysis.Levels;

namespace Ponics.Tests
{
    public class MockTolerance : Tolerance
    {
        public MockTolerance() : this(0, 0, 0, 0)
        {
        }

        public MockTolerance(double lower, double upper, double desiredLower, double desiredUpper) : base(lower, upper, desiredLower, desiredUpper)
        {
        }

        public override Scale Scale { get; }
    }
}
