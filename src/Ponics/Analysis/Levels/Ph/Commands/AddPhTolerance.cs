using Ponics.Analysis.Levels.Commands;
using ServiceStack;

namespace Ponics.Analysis.Levels.Ph.Commands
{
    [Api("Add a pH tolerance to an organism")]
    [Route("/organisms/{OrganismId}/tolerances/ph", "POST")]
    public class AddPhTolerance:AddTolerance<PhTolerance>
    {
        public override PhTolerance Tolerance { get; set; }
    }
}
