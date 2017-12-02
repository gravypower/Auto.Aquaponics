using ServiceStack;

namespace Ponics.Analysis.Levels.Ammonia
{
    [Api("Add Ammonia tolerance to an organism")]
    [Route("/organisms/{OrganismId}/tolerances/ammonia", "POST")]
    public class AddAmmoniaTolerance:AddTolerance<AmmoniaTolerance>
    {
        public override AmmoniaTolerance Tolerance { get; set; }
    }
}