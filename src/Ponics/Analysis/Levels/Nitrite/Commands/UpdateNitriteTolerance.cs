using Ponics.Analysis.Levels.Commands;
using ServiceStack;

namespace Ponics.Analysis.Levels.Nitrite.Commands
{
    [Api("Deletes the Nitrite tolerance off an organism")]
    [Route("/organisms/{OrganismId}/tolerances/nitrite", "DELETE")]
    public class DeleteNitriteTolerance: DeleteTolerance<NitriteTolerance>
    {
        public override NitriteTolerance Tolerance { get; set; }
    }
}
