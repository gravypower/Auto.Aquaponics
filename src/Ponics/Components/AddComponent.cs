using System;
using Ponics.Commands;
using Ponics.Kernel.Data;
using ServiceStack;

namespace Ponics.Components
{
    [Api("Adds a component to a system")]
    [Route("/systems/{SystemsId}/components", "POST")]
    public class AddComponent : Command, IDataCommand
    {
        [ApiMember(Name = "SystemId", Description = "The id of an organism",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("SystemId", typeof(Guid))]
        public Guid SystemId { get; set; }

        [ApiMember(ExcludeInSchema = true)]
        public Component Component { get; set; }
    }
}
