using System;
using Ponics.Commands;
using Ponics.Kernel.Data;
using ServiceStack;

namespace Ponics.Organisms
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