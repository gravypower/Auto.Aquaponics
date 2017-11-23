using ServiceStack;

namespace Auto.Aquaponics.Analysis.Level.Nitrite
{
    [Api("Returns Analysis of Nitrite level for an Organism")]
    [Route("/LevelAnalysis/Nitrite", "POST")]
    public class NitriteLevelAnalysisQuery : LevelAnalysisQuery<NitriteLevelAnalysis>
    {
    }
}
