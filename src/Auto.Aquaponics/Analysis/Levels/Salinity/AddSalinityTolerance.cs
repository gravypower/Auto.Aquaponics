using ServiceStack;

namespace Auto.Aquaponics.Analysis.Levels.Salinity
{
    [Api("Add Salinity Tolerance to an Organism")]
    [Route("/organisms/{OrganismId}/Tolerances/Salinity", "POST")]
    public class AddSalinityTolerance:AddTolerance<SalinityTolerance>
    {
        [ApiMember(Name = "Tolerance", Description = "Salinity tolerance for an Organism",
            ParameterType = "body", DataType = "SalinityTolerance", IsRequired = true)]
        public override SalinityTolerance Tolerance { get; set; }
    }
}
