using System;
using ServiceStack;
using Auto.Aquaponics.Queries;

namespace Auto.Aquaponics.AquaponicSystems
{
    [Api("Get an Aquaponic Systems by Id")]
    [Route("/systems/{id}", "GET")]
    public class GetSystem : Query<AquaponicSystem>
    {
        [ApiMember(Name = "Id", Description = "The Id of a system",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("Id", typeof(Guid))]
        public Guid Id { get; set; }
    }
}
