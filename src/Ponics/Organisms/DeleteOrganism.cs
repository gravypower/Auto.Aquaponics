using System;
using Ponics.Kernel.Commands;
using ServiceStack;

namespace Ponics.Organisms
{
    [Api("Deletes an Organism")]
    [Route("/organisms/{OrganismId}", "DELETE")]
    public class DeleteOrganism : Command, IDataCommand
    {
        [ApiMember(Name = "OrganismId", Description = "The Id of an organism",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("OrganismId", typeof(Guid))]
        public Guid OrganismId { get; set; }
    }
}