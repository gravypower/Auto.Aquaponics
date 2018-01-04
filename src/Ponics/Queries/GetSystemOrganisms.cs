using System;
using System.Collections.Generic;
using Ponics.Kernel.Queries;
using Ponics.Organisms;
using ServiceStack;

namespace Ponics.Queries
{
    [Api("Get all Organisms in an Aquaponic System")]
    [Route("/systems/{SystemId}/organisms", "GET")]
    public class GetSystemOrganisms : IQuery<List<Organism>>
    {
        [ApiMember(Name = "SystemId", Description = "The Id of a system",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("SystemId", typeof(Guid))]
        public Guid SystemId { get; set; }
    }
}
