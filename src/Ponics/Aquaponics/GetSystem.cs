using System;
using Ponics.Kernel.Data;
using Ponics.Queries;
using ServiceStack;

namespace Ponics.Aquaponics
{
    [Api("Get an Aquaponic Systems by Id")]
    [Route("/aquaponic/systems/{id}", "GET")]
    public class GetSystem : Query<AquaponicSystem>, IDataQuery<AquaponicSystem>
    {
        [ApiMember(Name = "Id", Description = "The Id of a system",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("Id", typeof(Guid))]
        public Guid Id { get; set; }
    }
}
