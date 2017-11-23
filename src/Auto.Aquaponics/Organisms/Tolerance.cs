namespace Auto.Aquaponics.Organisms
{
    public class Tolerance
    {
        public Scale Scale  { get; }
        public string Name { get; }
        public double Upper { get; }
        public double Lower { get; }
        public double DesiredLower { get; }
        public double DesiredUpper { get; }

        protected Tolerance()
        {
        }

        public Tolerance(string name, Scale scale, double lower, double upper, double desiredLower, double desiredUpper)
        {
            Scale = scale;
            Name = name;
            Lower = lower;
            DesiredLower = desiredLower;
            DesiredUpper = desiredUpper;
            Upper = upper;
        }
    }
}