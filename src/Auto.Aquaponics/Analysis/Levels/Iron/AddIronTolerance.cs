using ServiceStack;

namespace Auto.Aquaponics.Analysis.Levels.Iron
{
    [Api("Add Iron Tolerance to an Organism")]
    [Route("/organisms/{OrganismId}/Tolerances/Iron", "POST")]
    public class AddIronTolerance: AddTolerance<IronTolerance>
    {
    }
}
