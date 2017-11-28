using System;
using Auto.Aquaponics.Commands;
using Auto.Aquaponics.Kernel.Data;

namespace Auto.Aquaponics.Analysis.Levels
{
    public abstract class AddTolerance<TTolerance>: Command, IDataCommand
        where TTolerance:Tolerance
    {
        public Guid OrganismId { get; set; }
        public TTolerance Tolerance { get; set; }
    }
}
