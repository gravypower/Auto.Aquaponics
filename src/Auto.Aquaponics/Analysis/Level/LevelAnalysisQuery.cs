using ServiceStack;
using System;

namespace Auto.Aquaponics.Analysis.Level
{
    public abstract class LevelAnalysisQuery<TLevelAnalysis> : Query.IQuery<TLevelAnalysis>
        where TLevelAnalysis : LevelAnalysis
    {
        [ApiMember(Name = "OrganismId", Description = "The Id of an Organism",
        ParameterType = "body", DataType = "Guid", IsRequired = true)]
        public Guid OrganismId { get; set; }

        [ApiMember(Name = "Value", Description = "The value of the level",
        ParameterType = "body", DataType = "double", IsRequired = true)]
        public double Value { get; set; }
    }
}
