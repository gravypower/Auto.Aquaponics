using Ponics.Analysis.Levels.Commands;
using ServiceStack;

namespace Ponics.Analysis.Levels.Ammonia.Commands
{
    [Api("Add a Ammonia tolerance to an organism")]
    [Route("/organisms/{OrganismId}/tolerances/ammonia", "POST")]
    public class AddAmmoniaTolerance:AddTolerance<AmmoniaTolerance>
    {
        public override AmmoniaTolerance Tolerance { get; set; }
    }
}