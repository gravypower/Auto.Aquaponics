using System;
using Auto.Aquaponics.Commands;
using Auto.Aquaponics.Kernel.Data;
using ServiceStack;

namespace Auto.Aquaponics.AquaponicSystems
{
    [Api("Add an Aquaponic Systems")]
    [Route("/systems/{id}", "PUT")]
    public class UpdateSystem : Command, IDataCommand
    {
        [ApiMember(Name = "Id", Description = "The Id of an aquaponic system",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("Id", typeof(Guid))]
        public Guid Id { get; set; }

        public AquaponicSystem System { get; set; }
    }
}
