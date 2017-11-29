using ServiceStack;

namespace Auto.Aquaponics.Analysis.Levels.Nitrate
{
    [Api("Add Nitrate Tolerance to an Organism")]
    [Route("/organisms/{OrganismId}/Tolerances/Nitrate", "POST")]
    public class AddNitrateTolerance : AddTolerance<NitrateTolerance>
    {
        [ApiMember(Name = "Tolerance", Description = "Nitrate tolerance for an Organism",
            ParameterType = "body", DataType = "NitrateTolerance", IsRequired = true)]
        public override NitrateTolerance Tolerance { get; set; }
    }
}
