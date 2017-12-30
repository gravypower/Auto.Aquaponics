using System;
using System.Collections.Generic;
using Ponics.Organisms;
using Ponics.Queries;
using ServiceStack;

namespace Ponics.Aquaponics
{
    [Api("Get all Organisms in an Aquaponic System")]
    [Route("/aquaponic/systems/{id}/organisms", "GET")]
    public class GetSystemOrganisms : Query<List<Organism>>
    {
        [ApiMember(Name = "Id", Description = "The Id of a system",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("Id", typeof(Guid))]
        public Guid Id { get; set; }
    }
}
