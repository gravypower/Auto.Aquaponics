using ServiceStack;
using System;
using Ponics.Queries;

namespace Ponics.Analysis.Levels
{
    public abstract class AnalyseToleranceQuery<TLevelAnalysis, TTolerance> : Query<TLevelAnalysis>
        where TLevelAnalysis : LevelAnalysis<TTolerance> 
        where TTolerance : Tolerance
    {
        [ApiMember(Name = "OrganismId", Description = "The id of an organism",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("OrganismId", typeof(Guid))]
        public Guid OrganismId { get; set; }

        [ApiMember(Name = "Value", Description = "The value of the level",
        ParameterType = "path", DataType = "number", Format = "double", IsRequired = true)]
        public double Value { get; set; }
    }
}
