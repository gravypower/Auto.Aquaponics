using System;
using Ponics.Commands;
using Ponics.Kernel.Data;
using ServiceStack;

namespace Ponics.Organisms
{
    [Api("Updates an Organism")]
    [Route("/organisms/{OrganismId}", "PUT")]
    public class UpdateOrganism : Command, IDataCommand
    {
        [ApiMember(Name = "OrganismId", Description = "The Id of an organism",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("OrganismId", typeof(Guid))]
        public Guid OrganismId { get; set; }

        public Organism Organism { get; set; }
    }
}