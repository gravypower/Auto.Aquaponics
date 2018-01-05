using Ponics.Analysis.Levels.Commands;
using Ponics.Organisms.Tolerances;
using ServiceStack;

namespace Ponics.Analysis.Levels.Salinity.Commands
{
    [Api("Updates the salinity tolerance of an organism")]
    [Route("/organisms/{OrganismId}/tolerances/salinity", "PUT")]
    public class UpdateSalinityTolerance : UpdateTolerance<SalinityTolerance>
    {
        public override SalinityTolerance Tolerance { get; set; }
    }
}
