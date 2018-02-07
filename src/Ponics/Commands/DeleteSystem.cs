using System;
using Ponics.Kernel.Commands;
using ServiceStack;

namespace Ponics.Aquaponics.Commands
{
    [Api("Add an Aquaponic System")]
    [Route("/systems/{SystemId}", "DELETE")]
    public class DeleteSystem : ICommand, IDataCommand
    {
        [ApiMember(Name = "SystemId", Description = "The Id of an aquaponic system",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("SystemId", typeof(Guid))]
        public Guid SystemId { get; set; }
    }
}