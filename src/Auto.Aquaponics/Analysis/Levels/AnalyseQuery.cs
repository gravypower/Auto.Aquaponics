using ServiceStack;
using System;

namespace Auto.Aquaponics.Analysis.Levels
{
    public abstract class AnalyseQuery<TLevelAnalysis> : Query.IQuery<TLevelAnalysis>
        where TLevelAnalysis : Analysis
    {
        [ApiMember(Name = "OrganismId", Description = "The Id of an Organism",
        ParameterType = "body", DataType = "Guid", IsRequired = true)]
        public Guid OrganismId { get; set; }

        [ApiMember(Name = "Value", Description = "The value of the level",
        ParameterType = "body", DataType = "double", IsRequired = true)]
        public double Value { get; set; }
    }
}
