using System;
using Ponics.Kernel.Queries;
using ServiceStack;

namespace Ponics.Organisms.Queries
{
    [Api("Get an organism by Id")]
    [Route("/organisms/{OrganismId}", "GET")]
    public class GetOrganism : IQuery<Organism>, IDataQuery<Organism>
    {
        [ApiMember(Name = "OrganismId", Description = "The Id of an Organism",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("OrganismId", typeof(Guid))]
        public Guid OrganismId { get; set; }
    }
}
