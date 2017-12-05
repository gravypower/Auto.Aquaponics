using ServiceStack;

namespace Ponics.Analysis.Levels.Salinity
{
    [Api("Deletes the salinity tolerance off an organism")]
    [Route("/organisms/{OrganismId}/tolerances/salinity", "DELETE")]
    public class DeleteSalinityTolerance : DeleteTolerance
    {
    }
}
