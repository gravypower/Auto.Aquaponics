using ServiceStack;

namespace Auto.Aquaponics.Analysis.Levels
{
    public abstract class Tolerance
    {
        public string Type => GetType().Name;

        [ApiMember(ExcludeInSchema = true)]
        public abstract Scale Scale  { get; }

        [ApiMember(Name = "Upper", Description = "Upper bound level an organism can tolerate",
            ParameterType = "body", DataType = "number", Format = "double", IsRequired = true)]
        public double Upper { get; set; }

        [ApiMember(Name = "Lower", Description = "Lower bound level an organism can tolerate",
            ParameterType = "body", DataType = "number", Format = "double", IsRequired = true)]
        public double Lower { get; set;}


        [ApiMember(Name = "DesiredUpper", Description = "Desired upper bound level for an organism",
            ParameterType = "body", DataType = "number", Format = "double", IsRequired = true)]
        public double DesiredUpper { get; set; }

        [ApiMember(Name = "DesiredLower", Description = "Desired lower bound level for an organism",
            ParameterType = "body", DataType = "number", Format = "double", IsRequired = true)]
        public double DesiredLower { get; set;}
        

        protected Tolerance(double lower, double upper, double desiredLower, double desiredUpper)
        {
            Lower = lower;
            DesiredLower = desiredLower;
            DesiredUpper = desiredUpper;
            Upper = upper;
        }
    }
}