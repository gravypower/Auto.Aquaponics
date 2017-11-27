namespace Auto.Aquaponics.Analysis.Levels
{
    public abstract class Tolerance
    {
        public abstract Scale Scale  { get; }
        public double Upper { get; set; }
        public double Lower { get; set;}
        public double DesiredLower { get; set;}
        public double DesiredUpper { get; set;}

        protected Tolerance(double lower, double upper, double desiredLower, double desiredUpper)
        {
            Lower = lower;
            DesiredLower = desiredLower;
            DesiredUpper = desiredUpper;
            Upper = upper;
        }
    }
}