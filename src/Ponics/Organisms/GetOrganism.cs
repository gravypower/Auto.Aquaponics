using System;
using Ponics.Kernel.Queries;
using Ponics.Queries;
using ServiceStack;

namespace Ponics.Organisms
{
    [Api("Get an organism by Id")]
    [Route("/organisms/{OrganismId}", "GET")]
    public class GetOrganism :Query<Organism>, IDataQuery<Organism>
    {
        [ApiMember(Name = "OrganismId", Description = "The Id of an Organism",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("OrganismId", typeof(Guid))]
        public Guid OrganismId { get; set; }
    }
}
