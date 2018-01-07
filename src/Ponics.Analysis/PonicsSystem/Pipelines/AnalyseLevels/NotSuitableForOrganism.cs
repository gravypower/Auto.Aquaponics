using Ponics.Kernel.Pipelines;
using Ponics.Organisms;

namespace Ponics.Analysis.PonicsSystem.Pipelines.AnalyseLevels
{
    public class NotSuitableForOrganism: Node<PonicsSystemAnalysis, AnalyseLevelsPipelineContext>
    {
        public override PonicsSystemAnalysis DoExecute(PonicsSystemAnalysis input)
        {

            input.Add(new PonicsSystemAnalysisItem
            {
                PonicsSystemAnalysisType = PonicsSystemAnalysisType.Error,
                Title = $"{Context.LevelReading.Type} level not suitable!",
                Message = $"A {Context.LevelReading.Type} level of {Context.LevelReading.Value} is not Suitable for {Context.Organism.Name}",
            });

            return input;
        }

        public override bool ExecuteCondition()
        {
            return !Context.LevelAnalysis.SuitableForOrganism;
        }
    }
}
