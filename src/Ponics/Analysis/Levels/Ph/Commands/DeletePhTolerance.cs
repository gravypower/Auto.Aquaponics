using Ponics.Analysis.Levels.Commands;
using ServiceStack;

namespace Ponics.Analysis.Levels.Ph.Commands
{
    [Api("Deletes the pH tolerance from an organism")]
    [Route("/organisms/{OrganismId}/tolerances/ph", "DELETE")]
    public class DeletePhTolerance:DeleteTolerance<PhTolerance>
    {
        public override PhTolerance Tolerance { get; set; }
    }
}
