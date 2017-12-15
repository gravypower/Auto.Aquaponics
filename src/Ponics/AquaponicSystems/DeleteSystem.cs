using System;
using Ponics.Commands;
using Ponics.Kernel.Data;
using ServiceStack;

namespace Ponics.AquaponicSystems
{
    [Api("Add an Aquaponic System")]
    [Route("/systems/{id}", "DELETE")]
    public class DeleteSystem : Command, IDataCommand
    {
        [ApiMember(Name = "Id", Description = "The Id of an aquaponic system",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("Id", typeof(Guid))]
        public Guid Id { get; set; }
    }
}