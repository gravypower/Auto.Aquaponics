using ServiceStack;

namespace Ponics.Analysis.Levels.Ph
{
    [Api("Updates the pH tolerance of an organism")]
    [Route("/organisms/{OrganismId}/tolerances/ph", "PUT")]
    public class UpdatePhTolerance:UpdateTolerance<PhTolerance>
    {
        public override PhTolerance Tolerance { get; set; }
    }
}
