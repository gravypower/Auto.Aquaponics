using System;
using ServiceStack;

namespace Ponics.Components
{
    public class ComponentConnection
    {
        [ApiMember(Name = "SourceId", Description = "The id of the source component",
            ParameterType = "body", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("SourceId", typeof(Guid))]
        public Guid SourceId { get; set; }

        [ApiMember(Name = "DestinationId", Description = "The id of the destination component",
            ParameterType = "body", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("DestinationId", typeof(Guid))]
        public Guid TargetId { get; set; }
    }
}