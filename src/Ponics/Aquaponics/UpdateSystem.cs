using System;
using Ponics.Commands;
using Ponics.Kernel.Data;
using ServiceStack;

namespace Ponics.Aquaponics
{
    [Api("Update an Aquaponic Systems")]
    [Route("/aquaponic/systems/{id}", "PUT")]
    public class UpdateSystem : Command, IDataCommand
    {
        [ApiMember(Name = "Id", Description = "The Id of an aquaponic system",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("Id", typeof(Guid))]
        public Guid Id { get; set; }

        public AquaponicSystem System { get; set; }
    }
}
