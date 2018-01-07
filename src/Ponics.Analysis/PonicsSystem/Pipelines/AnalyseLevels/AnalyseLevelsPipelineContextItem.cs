using Ponics.Analysis.Levels;
using Ponics.Organisms;

namespace Ponics.Analysis.PonicsSystem.Pipelines.AnalyseLevels
{
    public class AnalyseLevelsPipelineContextItem
    {
        public readonly LevelAnalysis LevelAnalysis;
        public readonly LevelReading LevelReading;
        public readonly Organism Organism;

        public AnalyseLevelsPipelineContextItem(
            LevelAnalysis levelAnalysis, 
            LevelReading levelReading,
            Organism organism)
        {
            LevelAnalysis = levelAnalysis;
            LevelReading = levelReading;
            Organism = organism;
        }
    }
}
