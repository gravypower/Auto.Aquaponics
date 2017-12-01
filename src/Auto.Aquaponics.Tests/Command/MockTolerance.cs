using Auto.Aquaponics.Analysis.Levels;

namespace Auto.Aquaponics.Tests.Command
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
