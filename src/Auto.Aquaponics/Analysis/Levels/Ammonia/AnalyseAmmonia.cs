using ServiceStack;

namespace Auto.Aquaponics.Analysis.Levels.Ammonia
{
    [Api("Returns Analysis of Ammonia levels for an Organism")]
    [Route("/Levels/Ammonia", "GET,POST")]
    public class AnalyseAmmonia : AnalyseQuery<AmmoniaAnalysis, AmmoniaTolerance>
    {
    }
}
