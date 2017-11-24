using ServiceStack;

namespace Auto.Aquaponics.Analysis.Levels.Nitrate
{
    [Api("Returns Analysis of Nitrate levels for an Organism")]
    [Route("/Levels/Nitrate", "POST")]
    public class AnalyseNitrate : AnalyseQuery<NitrateAnalysis>
    {
    }
}
