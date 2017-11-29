using ServiceStack;
using System;
using Auto.Aquaponics.Queries;

namespace Auto.Aquaponics.Analysis.Levels
{
    public abstract class AnalyseQuery<TLevelAnalysis, TTolerance> : Query<TLevelAnalysis>
        where TLevelAnalysis : Analysis<TTolerance> 
        where TTolerance : Tolerance
    {
        [ApiMember(Name = "OrganismId", Description = "The Id of an Organism",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("OrganismId", typeof(Guid))]
        public Guid OrganismId { get; set; }

        [ApiMember(Name = "Value", Description = "The value of the level",
        ParameterType = "path", DataType = "number", Format = "double", IsRequired = true)]
        public double Value { get; set; }
    }
}
