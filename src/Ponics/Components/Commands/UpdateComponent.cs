using System;
using Ponics.Kernel.Commands;
using ServiceStack;

namespace Ponics.Components.Commands
{
    [Api("Updates a component in a system")]
    [Route("/systems/{SystemId}/components/{ComponentId}", "PUT")]
    public class UpdateComponent : ICommand, IDataCommand
    {
        [ApiMember(Name = "SystemId", Description = "The id of a System",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("SystemId", typeof(Guid))]
        public Guid SystemId { get; set; }

        [ApiMember(Name = "ComponentId", Description = "The id of a Component",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("ComponentId", typeof(Guid))]
        public Guid ComponentId { get; set; }

        public Component Component { get; set; }
    }
}
