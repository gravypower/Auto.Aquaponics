using Auto.Aquaponics.Kernel;

namespace Auto.Aquaponics.Organisms
{
    public class Tolerance
    {
        public Scale Scale  { get; private set; }
        public string Name { get; private set; }
        public double Upper { get; private set; }
        public double Lower { get; private set; }
        public double DesiredLower { get; private set; }
        public double DesiredUpper { get; private set; }

        protected Tolerance()
        {
            
        }

        public Tolerance(string name, Scale scale, double upper, double lower, double desiredUpper, double desiredLower)
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
