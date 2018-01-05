using Ponics.Analysis.Levels.Commands;
using Ponics.Organisms.Tolerances;
using ServiceStack;

namespace Ponics.Analysis.Levels.Nitrate.Commands
{
    [Api("Add a Nitrate tolerance to an organism")]
    [Route("/organisms/{OrganismId}/tolerances/nitrate", "POST")]
    public class AddNitrateTolerance : AddTolerance<NitrateTolerance>
    {
        public override NitrateTolerance Tolerance { get; set; }
    }
}
