using Ponics.Analysis.Levels.Commands;
using Ponics.Organisms.Tolerances;
using ServiceStack;

namespace Ponics.Analysis.Levels.Nitrite.Commands
{
    [Api("Updates the Nitrite tolerance of an organism")]
    [Route("/organisms/{OrganismId}/tolerances/nitrite", "POST")]
    public class UpdateNitriteTolerance: UpdateTolerance<NitriteTolerance>
    {
        public override NitriteTolerance Tolerance { get; set; }
    }
}
