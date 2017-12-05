using ServiceStack;

namespace Ponics.Analysis.Levels.Ammonia
{
    [Api("Deletes the Ammonia tolerance off an organism")]
    [Route("/organisms/{OrganismId}/tolerances/ammonia", "DELETE")]
    public class DeleteAmmoniaTolerance:DeleteTolerance
    {
    }
}