using System;
using Ponics.Commands;
using Ponics.Kernel.Commands;
using ServiceStack;

namespace Ponics.Aquaponics
{
    [Api("Add an Aquaponic System")]
    [Route("/systems/aquaponic/{SystemId}", "DELETE")]
    [Tag("aquaponic")]
    public class DeleteSystem : Command, IDataCommand
    {
        [ApiMember(Name = "SystemId", Description = "The Id of an aquaponic system",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("SystemId", typeof(Guid))]
        public Guid SystemId { get; set; }
    }
}