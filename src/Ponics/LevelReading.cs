using NodaTime;
using ServiceStack;

namespace Ponics.Analysis.Levels
{
    public class LevelReading
    {
        [ApiMember(Name = "DateTime", Description = "The of a System",
            ParameterType = "body", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("DateTime", typeof(ZonedDateTime))]
        public ZonedDateTime DateTime { get; set; }

        [ApiMember(Name = "Type", Description = "The the type of the reading",
            ParameterType = "body", DataType = "string", IsRequired = true)]
        public string Type { get; set; }

        [ApiMember(Name = "Value", Description = "The value of the reading",
            ParameterType = "body", DataType = "number", Format = "double", IsRequired = true)]
        public double Value { get; set; }
    }
}
