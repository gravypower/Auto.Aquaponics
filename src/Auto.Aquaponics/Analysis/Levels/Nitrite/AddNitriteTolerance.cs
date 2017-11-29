using ServiceStack;

namespace Auto.Aquaponics.Analysis.Levels.Nitrite
{
    [Api("Add Nitrite Tolerance to an Organism")]
    [Route("/organisms/{OrganismId}/Tolerances/Nitrite", "POST")]
    public class AddNitriteTolerance: AddTolerance<NitriteTolerance>
    {
        [ApiMember(Name = "Tolerance", Description = "Nitrite tolerance for an Organism",
            ParameterType = "body", DataType = "NitriteTolerance", IsRequired = true)]
        public override NitriteTolerance Tolerance { get; set; }
    }
}
