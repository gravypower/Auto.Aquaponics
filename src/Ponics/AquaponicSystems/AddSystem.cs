using Ponics.Commands;
using Ponics.Kernel.Data;
using ServiceStack;

namespace Ponics.AquaponicSystems
{
    [Api("Add an Aquaponic Systems")]
    [Route("/systems", "POST")]
    public class AddSystem : Command, IDataCommand
    {
        [ApiMember(ExcludeInSchema = true)]
        public AquaponicSystem System { get; set; }
    }
}