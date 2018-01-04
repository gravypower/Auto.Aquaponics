using System;
using System.Collections.Generic;
using Ponics.Analysis.Levels;
using Ponics.Kernel.Queries;
using ServiceStack;

namespace Ponics.Queries
{
    [Api("Gets level readings for system")]
    [Route("/systems/{SystemId}/reading/{Type}", "GET")]
    public class GetSystemLevels : Query<List<LevelReading>>
    {
        [ApiMember(Name = "SystemId", Description = "The Id of a system",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("SystemId", typeof(Guid))]
        public Guid SystemId { get; set; }

        [ApiMember(Name = "Type", Description = "The type of level reading to get",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        public string Type { get; set; }
    }
}
