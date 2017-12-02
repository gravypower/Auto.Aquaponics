using System;
using Ponics.Commands;
using Ponics.Kernel.Data;
using ServiceStack;

namespace Ponics.Components
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
