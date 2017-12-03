using Ponics.Commands;
using Ponics.Kernel.Data;
using ServiceStack;

namespace Ponics.AquaponicSystems
{
    [Api("Add an Aquaponic System")]
    [Route("/systems", "POST")]
    public class AddSystem : Command, IDataCommand
    {
        public AquaponicSystem System { get; set; }
    }
}