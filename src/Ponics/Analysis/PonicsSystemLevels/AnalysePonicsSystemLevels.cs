using System;
using Ponics.Queries;
using ServiceStack;

namespace Ponics.Analysis.PonicsSystemLevels
{

    [Api("Runs analysis on a system using the latest level readings")]
    [Route("/systems/{SystemId}/analysis", "GET")]
    [Tag("analysis")]
    public class AnalysePonicsSystemLevels : Query<PonicsSystemLevelsAnalysis>
    {
        [ApiMember(Name = "SystemId", Description = "The Id of a system",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("SystemId", typeof(Guid))]
        public Guid SystemId { get; }
    }
}
