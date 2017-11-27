using System;
using Auto.Aquaponics.Commands;
using Auto.Aquaponics.Kernel.Data;
using ServiceStack;

namespace Auto.Aquaponics.Organisms
{
    [Api("Adds and Organism")]
    [Route("/organisms/{id}", "PUT")]
    public class UpdateOrganism : Command, IDataCommand
    {
        public Guid Id { get; set; }
        public Organism Organism { get; set; }
    }
}
