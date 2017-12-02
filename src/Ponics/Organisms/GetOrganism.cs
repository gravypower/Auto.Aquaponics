using System;
using Ponics.Kernel.Data;
using Ponics.Queries;
using ServiceStack;

namespace Ponics.Organisms
{
    [Api("Get an organism by Id")]
    [Route("/organisms/{id}", "GET")]
    public class GetOrganism :Query<Organism>, IDataQuery<Organism>
    {
        [ApiMember(Name = "Id", Description = "The Id of an Organism",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("Id", typeof(Guid))]
        public Guid Id { get; set; }
    }
}
