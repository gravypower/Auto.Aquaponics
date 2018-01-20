using System;
using Ponics.Kernel.Commands;
using ServiceStack;

namespace Ponics.Aquaponics.Commands
{
    [Api("Update an Aquaponic Systems")]
    [Route("/systems/aquaponic/{SystemId}", "PUT")]
    [Tag("aquaponic")]
    public class UpdateSystem : ICommand, IDataCommand
    {
        [ApiMember(Name = "SystemId", Description = "The Id of an aquaponic system",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("SystemId", typeof(Guid))]
        public Guid SystemId { get; set; }

        public AquaponicSystem System { get; set; }
    }
}
