using ServiceStack;

namespace Auto.Aquaponics.Analysis.Levels.Ammonia
{
    [Api("Returns Analysis of Ammonia levels for an Organism")]
    [Route("/organisms/{OrganismId}/Tolerances/Ammonia/{Value}", "GET")]
    public class AnalyseAmmonia : AnalyseQuery<AmmoniaAnalysis, AmmoniaTolerance>
    {
    }
}
