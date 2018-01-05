using Ponics.Analysis.Levels.Commands;
using Ponics.Organisms.Tolerances;
using ServiceStack;

namespace Ponics.Analysis.Levels.Ph.Commands
{
    [Api("Deletes the pH tolerance from an organism")]
    [Route("/organisms/{OrganismId}/tolerances/ph", "DELETE")]
    public class DeletePhTolerance:DeleteTolerance<PhTolerance>
    {
    }
}
