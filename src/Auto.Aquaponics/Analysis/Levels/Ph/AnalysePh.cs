using ServiceStack;

namespace Auto.Aquaponics.Analysis.Levels.Ph
{
    [Api("Returns Analysis of Ph levels for an Organism")]
    [Route("/Levels/Ph", "GET,POST")]
    public class AnalysePh : AnalyseQuery<PhAnalysis>
    {
    }
}
