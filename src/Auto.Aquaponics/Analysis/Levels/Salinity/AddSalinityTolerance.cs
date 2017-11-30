using ServiceStack;

namespace Auto.Aquaponics.Analysis.Levels.Salinity
{
    [Api("Add Salinity Tolerance to an Organism")]
    [Route("/organisms/{OrganismId}/Tolerances/Salinity", "POST")]
    public class AddSalinityTolerance:AddTolerance<SalinityTolerance>
    {
        public override SalinityTolerance Tolerance { get; set; }
    }
}
