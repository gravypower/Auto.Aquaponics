using Ponics.Analysis.Levels.Commands;
using Ponics.Organisms.Tolerances;
using ServiceStack;

namespace Ponics.Analysis.Levels.Nitrite.Commands
{
    [Api("Deletes the Nitrite tolerance off an organism")]
    [Route("/organisms/{OrganismId}/tolerances/nitrite", "DELETE")]
    public class DeleteNitriteTolerance: DeleteTolerance<NitriteTolerance>
    {
    }
}
