using ServiceStack;

namespace Ponics.Analysis.Levels.Iron
{
    [Api("Deletes the Iron tolerance off an organism")]
    [Route("/organisms/{OrganismId}/tolerances/iron", "DELETE")]
    public class DeleteIronTolerance: DeleteTolerance
    {
    }
}
