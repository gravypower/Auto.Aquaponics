using System;
using Ponics.Kernel.Queries;
using ServiceStack;

namespace Ponics.Aquaponics.Queries
{
    [Api("Get an Aquaponic Systems by Id")]
    [Route("/systems/aquaponic/{SystemId}", "GET")]
    [Tag("aquaponic")]
    public class GetAquaponicSystem : IQuery<AquaponicSystem>, IDataQuery<AquaponicSystem>
    {
        [ApiMember(Name = "SystemId", Description = "The Id of a system",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("SystemId", typeof(Guid))]
        public Guid SystemId { get; set; }
    }
}
