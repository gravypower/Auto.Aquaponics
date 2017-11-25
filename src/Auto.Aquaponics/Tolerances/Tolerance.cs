namespace Auto.Aquaponics.Tolerances
{
    public abstract class Tolerance
    {
        public abstract Scale Scale  { get; }
        public double Upper { get; }
        public double Lower { get; }
        public double DesiredLower { get; }
        public double DesiredUpper { get; }


        protected Tolerance(double lower, double upper, double desiredLower, double desiredUpper)
        {
            Lower = lower;
            DesiredLower = desiredLower;
            DesiredUpper = desiredUpper;
            Upper = upper;
        }
    }
}