using ServiceStack;

namespace Ponics.Analysis.Levels.Nitrite
{
    [Api("Deletes the Nitrite tolerance off an organism")]
    [Route("/organisms/{OrganismId}/tolerances/nitrite", "DELETE")]
    public class DeleteNitriteTolerance: DeleteTolerance
    {
    }
}
