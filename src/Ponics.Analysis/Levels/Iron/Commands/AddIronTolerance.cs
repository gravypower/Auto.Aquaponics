using Ponics.Analysis.Levels.Commands;
using Ponics.Organisms.Tolerances;
using ServiceStack;

namespace Ponics.Analysis.Levels.Iron.Commands
{
    [Api("Add a Iron tolerance to an organism")]
    [Route("/organisms/{OrganismId}/tolerances/iron", "POST")]
    public class AddIronTolerance: AddTolerance<IronTolerance>
    {
        public override IronTolerance Tolerance { get; set; }
    }
}
