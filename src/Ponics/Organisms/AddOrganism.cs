using Ponics.Commands;
using Ponics.Kernel.Commands;
using Ponics.Kernel.Data;
using ServiceStack;

namespace Ponics.Organisms
{
    [Api("Adds and organism")]
    [Route("/organisms", "POST")]
    public class AddOrganism : Command, IDataCommand
    {
        public Organism Organism { get; set; }
    }
}
