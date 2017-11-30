using System;
using Auto.Aquaponics.Kernel.Data;
using Auto.Aquaponics.Queries;
using ServiceStack;

namespace Auto.Aquaponics.Organisms
{
    [Api("Get an Organism by Id")]
    [Route("/organisms/{id}", "GET")]
    public class GetOrganism :Query<Organism>, IDataQuery<Organism>
    {
        [ApiMember(Name = "Id", Description = "The Id of an Organism",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("Id", typeof(Guid))]
        public Guid Id { get; set; }
    }
}
