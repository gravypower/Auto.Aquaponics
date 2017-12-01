using Auto.Aquaponics.Commands;
using Auto.Aquaponics.Kernel.Data;
using ServiceStack;

namespace Auto.Aquaponics.AquaponicSystems
{
    [Api("Add an Aquaponic Systems")]
    [Route("/systems", "POST")]
    public class AddSystem : Command, IDataCommand
    {
        public AquaponicSystem System { get; set; }
    }
}