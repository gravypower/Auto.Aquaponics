using Auto.Aquaponics.Commands;
using Auto.Aquaponics.Kernel.Data;
using ServiceStack;

namespace Auto.Aquaponics.Organisms
{
    [Api("Adds and organism")]
    [Route("/organisms", "POST")]
    public class AddOrganism : Command, IDataCommand
    {
        public Organism Organism { get; set; }
    }
}
