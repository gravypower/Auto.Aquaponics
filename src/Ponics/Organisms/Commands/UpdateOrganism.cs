using System;
using Ponics.Kernel.Commands;
using ServiceStack;

namespace Ponics.Organisms.Commands
{
    [Api("Updates an Organism")]
    [Route("/organisms/{OrganismId}", "PUT")]
    public class UpdateOrganism : ICommand, IDataCommand
    {
        [ApiMember(Name = "OrganismId", Description = "The Id of an organism",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("OrganismId", typeof(Guid))]
        public Guid OrganismId { get; set; }

        public Organism Organism { get; set; }
    }
}