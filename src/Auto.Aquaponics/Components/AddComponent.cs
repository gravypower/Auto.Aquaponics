using System;
using Auto.Aquaponics.Commands;
using Auto.Aquaponics.Kernel.Data;
using ServiceStack;

namespace Auto.Aquaponics.Components
{
    [Api("Adds and organism")]
    [Route("/systems/{SystemsId}/components", "POST")]
    public class AddComponent : Command, IDataCommand
    {
        [ApiMember(Name = "SystemsId", Description = "The id of an organism",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("OrganismId", typeof(Guid))]
        public Guid SystemsId { get; set; }

        [ApiMember(ExcludeInSchema = true)]
        public Component Component { get; set; }
    }
}
