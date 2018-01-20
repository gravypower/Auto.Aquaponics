using Ponics.Kernel.Commands;
using ServiceStack;

namespace Ponics.Aquaponics.Commands
{
    [Api("Add an Aquaponic System")]
    [Route("/systems/aquaponic", "POST")]
    [Tag("aquaponic")]
    public class AddSystem : ICommand, IDataCommand
    {
        public PonicsSystem System { get; set; }
    }
}