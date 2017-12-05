using ServiceStack;

namespace Ponics.Analysis.Levels.Nitrate
{
    [Api("Deletes the Nitrate tolerance off an organism")]
    [Route("/organisms/{OrganismId}/tolerances/nitrate", "DELETE")]
    public class DeleteNitrateTolerance : DeleteTolerance
    {
    }
}
