using System;
using Auto.Aquaponics.Commands;

namespace Auto.Aquaponics.Analysis.Levels
{
    public abstract class AddTolerance<TTolerance>: Command
        where TTolerance:Tolerance
    {
        public Guid OrganismId { get; set; }
        public TTolerance Tolerance { get; set; }
    }
}
