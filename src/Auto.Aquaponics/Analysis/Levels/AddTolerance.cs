using System;
using Auto.Aquaponics.Commands;
using Auto.Aquaponics.Kernel.Data;
using ServiceStack;

namespace Auto.Aquaponics.Analysis.Levels
{
    public abstract class AddTolerance<TTolerance>: Command, IDataCommand
        where TTolerance:Tolerance
    {
        [ApiMember(Name = "OrganismId", Description = "The Id of an Organism",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("OrganismId", typeof(Guid))]
        public Guid OrganismId { get; set; }

        [ApiMember(ExcludeInSchema = true)]
        public abstract TTolerance Tolerance { get; set; }
    }
}