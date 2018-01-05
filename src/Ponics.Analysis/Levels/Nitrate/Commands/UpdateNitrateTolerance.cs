using Ponics.Analysis.Levels.Commands;
using Ponics.Organisms.Tolerances;
using ServiceStack;

namespace Ponics.Analysis.Levels.Nitrate.Commands
{
    [Api("Updates the Nitrate tolerance of an organism")]
    [Route("/organisms/{OrganismId}/tolerances/nitrate", "PUT")]
    public class UpdateNitrateTolerance : UpdateTolerance<NitrateTolerance>
    {
        public override NitrateTolerance Tolerance { get; set; }
    }
}
