using ServiceStack;

namespace Ponics.Analysis.Levels.Nitrate
{
    [Api("Add Nitrate tolerance to an organism")]
    [Route("/organisms/{OrganismId}/tolerances/nitrate", "POST")]
    public class AddNitrateTolerance : AddTolerance<NitrateTolerance>
    {
        public override NitrateTolerance Tolerance { get; set; }
    }
}
