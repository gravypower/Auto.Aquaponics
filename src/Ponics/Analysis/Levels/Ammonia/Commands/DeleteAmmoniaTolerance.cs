using Ponics.Analysis.Levels.Commands;
using ServiceStack;

namespace Ponics.Analysis.Levels.Ammonia.Commands
{
    [Api("Deletes the Ammonia tolerance off an organism")]
    [Route("/organisms/{OrganismId}/tolerances/ammonia", "DELETE")]
    public class DeleteAmmoniaTolerance:DeleteTolerance<AmmoniaTolerance>
    {
    }
}