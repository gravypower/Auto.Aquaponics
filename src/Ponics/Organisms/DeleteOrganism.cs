using System;
using Ponics.Commands;
using Ponics.Kernel.Data;
using ServiceStack;

namespace Ponics.Organisms
{
    [Api("Deletes an Organism")]
    [Route("/organisms/{id}", "DELETE")]
    public class DeleteOrganism : Command, IDataCommand
    {
        [ApiMember(Name = "Id", Description = "The Id of an organism",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("Id", typeof(Guid))]
        public Guid Id { get; set; }
    }
}