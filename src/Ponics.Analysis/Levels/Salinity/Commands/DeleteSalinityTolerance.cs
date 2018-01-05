using Ponics.Analysis.Levels.Commands;
using Ponics.Organisms.Tolerances;
using ServiceStack;

namespace Ponics.Analysis.Levels.Salinity.Commands
{
    [Api("Deletes the salinity tolerance off an organism")]
    [Route("/organisms/{OrganismId}/tolerances/salinity", "DELETE")]
    public class DeleteSalinityTolerance : DeleteTolerance<SalinityTolerance>
    {
    }
}
