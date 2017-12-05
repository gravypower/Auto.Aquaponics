using System;
using Ponics.Commands;
using ServiceStack;

namespace Ponics.Analysis.Levels
{
    public abstract class DeleteTolerance : Command
    {
        [ApiMember(Name = "OrganismId", Description = "The id of an organism",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("OrganismId", typeof(Guid))]
        public Guid OrganismId { get; set; }
    }
}
