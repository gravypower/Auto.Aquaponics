using Auto.Aquaponics.Commands;
using Auto.Aquaponics.Kernel.Data;

namespace Auto.Aquaponics.Organisms
{
    public class AddOrganism : Command, IDataCommand
    {
        public Organism Organism { get; set; }
    }
}
