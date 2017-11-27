using ServiceStack;

namespace Auto.Aquaponics.Analysis.Levels.Nitrate
{
    [Api("Returns Analysis of Nitrate levels for an Organism")]
    [Route("/Levels/Nitrate", "GET,POST")]
    public class AnalyseNitrate : AnalyseQuery<NitrateAnalysis, NitrateTolerance>
    {
    }
}
