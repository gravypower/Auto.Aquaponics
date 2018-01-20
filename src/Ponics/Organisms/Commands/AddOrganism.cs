using Ponics.Kernel.Commands;
using ServiceStack;

namespace Ponics.Organisms.Commands
{
    [Api("Adds and organism")]
    [Route("/organisms", "POST")]
    public class AddOrganism : ICommand, IDataCommand
    {
        public Organism Organism { get; set; }
    }
}
