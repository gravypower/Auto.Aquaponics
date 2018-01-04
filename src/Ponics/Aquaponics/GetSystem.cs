using System;
using Ponics.Kernel.Data;
using Ponics.Queries;
using ServiceStack;

namespace Ponics.Aquaponics
{
    [Api("Get an Aquaponic Systems by Id")]
    [Route("/systems/aquaponic/{SystemId}", "GET")]
    [Tag("aquaponic")]
    public class GetSystem : Query<AquaponicSystem>, IDataQuery<AquaponicSystem>
    {
        [ApiMember(Name = "SystemId", Description = "The Id of a system",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("SystemId", typeof(Guid))]
        public Guid SystemId { get; set; }
    }
}
