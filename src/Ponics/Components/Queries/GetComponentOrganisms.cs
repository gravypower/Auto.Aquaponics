using System;
using ServiceStack;

namespace Ponics.Components.Queries
{
    [Api("Get a list of the component organisms")]
    [Route("/systems/{SystemId}/components/{ComponentId}/organisms", "GET")]
    public class GetComponentOrganisms
    {
        [ApiMember(Name = "ComponentId", Description = "The id of a system",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("ComponentId", typeof(Guid))]
        public Guid ComponentId { get; set; }

        [ApiMember(Name = "SystemId", Description = "The Id of a system",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("SystemId", typeof(Guid))]
        public Guid SystemId { get; set; }
    }
}
