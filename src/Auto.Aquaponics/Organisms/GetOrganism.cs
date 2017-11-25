using System;
using Auto.Aquaponics.Queries;
using ServiceStack;

namespace Auto.Aquaponics.Organisms
{
    [Api("Get an Organism by Id")]
    [Route("/organisms/{id}", "GET")]
    public class GetOrganism :Query<Organism>
    {
        [ApiMember(Name = "Id", Description = "The Id of an Organism",
            ParameterType = "path", DataType = "Guid", IsRequired = true)]
        public Guid Id { get; set; }
    }
}
