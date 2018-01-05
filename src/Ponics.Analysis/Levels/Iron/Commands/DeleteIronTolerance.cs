using Ponics.Analysis.Levels.Commands;
using Ponics.Organisms.Tolerances;
using ServiceStack;

namespace Ponics.Analysis.Levels.Iron.Commands
{
    [Api("Deletes the Iron tolerance off an organism")]
    [Route("/organisms/{OrganismId}/tolerances/iron", "DELETE")]
    public class DeleteIronTolerance: DeleteTolerance<IronTolerance>
    {
    }
}
