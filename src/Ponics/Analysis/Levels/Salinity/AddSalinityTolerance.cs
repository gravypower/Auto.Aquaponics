using ServiceStack;

namespace Ponics.Analysis.Levels.Salinity
{
    [Api("Adds a salinity tolerance to an organism")]
    [Route("/organisms/{OrganismId}/tolerances/salinity", "POST")]
    public class AddSalinityTolerance:AddTolerance<SalinityTolerance>
    {
        public override SalinityTolerance Tolerance { get; set; }
    }
}
