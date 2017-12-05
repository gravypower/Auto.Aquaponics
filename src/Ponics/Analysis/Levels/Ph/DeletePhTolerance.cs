using ServiceStack;

namespace Ponics.Analysis.Levels.Ph
{
    [Api("Deletes the pH tolerance from an organism")]
    [Route("/organisms/{OrganismId}/tolerances/ph", "DELETE")]
    public class DeletePhTolerance:DeleteTolerance
    {
    }
}
