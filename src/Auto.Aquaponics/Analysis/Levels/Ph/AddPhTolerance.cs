using ServiceStack;

namespace Auto.Aquaponics.Analysis.Levels.Ph
{
    [Api("Add pH Tolerance to an Organism")]
    [Route("/organisms/{OrganismId}/Tolerances/Ph", "POST")]
    public class AddPhTolerance:AddTolerance<PhTolerance>
    {
        [ApiMember(Name = "Tolerance", Description = "Ph tolerance for an Organism",
            ParameterType = "body", DataType = "PhTolerance", IsRequired = true)]
        public override PhTolerance Tolerance { get; set; }
    }
}
