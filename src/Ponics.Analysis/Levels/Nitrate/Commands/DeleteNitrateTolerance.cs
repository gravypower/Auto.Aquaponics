using Ponics.Analysis.Levels.Commands;
using Ponics.Organisms.Tolerances;
using ServiceStack;

namespace Ponics.Analysis.Levels.Nitrate.Commands
{
    [Api("Deletes the Nitrate tolerance off an organism")]
    [Route("/organisms/{OrganismId}/tolerances/nitrate", "DELETE")]
    public class DeleteNitrateTolerance : DeleteTolerance<NitrateTolerance>
    {
    }
}
