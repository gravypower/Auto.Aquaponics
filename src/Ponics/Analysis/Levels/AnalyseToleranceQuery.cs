using ServiceStack;
using System;
using Ponics.Kernel.Queries;

namespace Ponics.Analysis.Levels
{
    public abstract class AnalyseToleranceQuery<TLevelAnalysis, TTolerance> : AnalyseToleranceQuery, IQuery<TLevelAnalysis>
        where TLevelAnalysis : LevelAnalysis<TTolerance> 
        where TTolerance : Tolerance
    {
        
    }

    public abstract class AnalyseToleranceQuery
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
