using ServiceStack;

namespace Ponics.Analysis.Levels.Ammonia
{
    [Api("Updates the Ammonia tolerance of an organism")]
    [Route("/organisms/{OrganismId}/tolerances/ammonia", "PUT")]
    public class UpdateAmmoniaTolerance:UpdateTolerance<AmmoniaTolerance>
    {
        public override AmmoniaTolerance Tolerance { get; set; }
    }
}