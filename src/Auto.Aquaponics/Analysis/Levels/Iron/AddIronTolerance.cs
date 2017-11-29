using ServiceStack;

namespace Auto.Aquaponics.Analysis.Levels.Iron
{
    [Api("Add Iron Tolerance to an Organism")]
    [Route("/organisms/{OrganismId}/Tolerances/Iron", "POST")]
    public class AddIronTolerance: AddTolerance<IronTolerance>
    {
        [ApiMember(Name = "Tolerance", Description = "Iron tolerance for an Organism",
            ParameterType = "body", DataType = "IronTolerance", IsRequired = true)]
        public override IronTolerance Tolerance { get; set; }
    }
}
