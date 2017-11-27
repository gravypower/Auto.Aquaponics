using ServiceStack;

namespace Auto.Aquaponics.Analysis.Levels.Iron
{
    [Api("Returns Analysis of Ammonia levels for an Organism")]
    [Route("/Levels/Ammonia", "GET,POST")]
    public class AnalyseIron : AnalyseQuery<IronAnalysis, IronTolerance>
    {
    }
}
