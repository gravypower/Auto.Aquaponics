using System;
using Ponics.Kernel.Queries;
using ServiceStack;

namespace Ponics.Analysis.PonicsSystem
{

    [Api("Runs analysis on a system using the latest level readings")]
    [Route("/systems/{SystemId}/analysis", "GET")]
    [Tag("analysis")]
    public class AnalysePonicsSystem : IQuery<PonicsSystemAnalysis>
    {
        [ApiMember(Name = "SystemId", Description = "The Id of a system",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("SystemId", typeof(Guid))]
        public Guid SystemId { get; set; }
    }
}
