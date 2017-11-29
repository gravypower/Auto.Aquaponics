using ServiceStack;

namespace Auto.Aquaponics.Analysis.Levels.Ammonia
{
    [Api("Add Ammonia Tolerance to an Organism")]
    [Route("/organisms/{OrganismId}/Tolerances/Ammonia", "POST")]
    public class AddAmmoniaTolerance:AddTolerance<AmmoniaTolerance>
    {
        [ApiMember(Name = "Tolerance", Description = "Ammonia tolerance for an Organism",
            ParameterType = "body", DataType = "AmmoniaTolerance", IsRequired = true)]
        public override AmmoniaTolerance Tolerance { get; set; }
    }
}
