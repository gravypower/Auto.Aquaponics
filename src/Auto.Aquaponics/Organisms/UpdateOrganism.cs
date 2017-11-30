using System;
using Auto.Aquaponics.Commands;
using Auto.Aquaponics.Kernel.Data;
using ServiceStack;

namespace Auto.Aquaponics.Organisms
{
    [Api("Updates and Organism")]
    [Route("/organisms/{id}", "PUT")]
    public class UpdateOrganism : Command, IDataCommand
    {
        [ApiMember(Name = "Id", Description = "The Id of an organism",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("Id", typeof(Guid))]
        public Guid Id { get; set; }

        public Organism Organism { get; set; }
    }
}
