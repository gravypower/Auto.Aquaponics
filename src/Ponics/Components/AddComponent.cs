using System;
using Ponics.Commands;
using Ponics.Kernel.Commands;
using ServiceStack;

namespace Ponics.Components
{
    [Api("Adds a component to a system")]
    [Route("/systems/{SystemId}/components", "POST")]
    public class AddComponent : Command, IDataCommand
    {
        [ApiMember(Name = "SystemId", Description = "The of a System",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("SystemId", typeof(Guid))]
        public Guid SystemId { get; set; }

        public Component Component { get; set; }
    }
}
