using ServiceStack;

namespace Auto.Aquaponics.Analysis.Levels.Ph
{
    [Api("Add pH tolerance to an organism")]
    [Route("/organisms/{OrganismId}/tolerances/ph", "POST")]
    public class AddPhTolerance:AddTolerance<PhTolerance>
    {
        public override PhTolerance Tolerance { get; set; }
    }
}
