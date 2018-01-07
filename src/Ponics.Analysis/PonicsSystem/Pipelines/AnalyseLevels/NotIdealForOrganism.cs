using Ponics.Kernel.Pipelines;
using Ponics.Organisms;

namespace Ponics.Analysis.PonicsSystem.Pipelines.AnalyseLevels
{
    public class NotIdealForOrganism: Node<PonicsSystemAnalysis, AnalyseLevelsPipelineContext>
    {
        public override PonicsSystemAnalysis DoExecute(PonicsSystemAnalysis input)
        {
            input.Add(new PonicsSystemAnalysisItem
            {
                PonicsSystemAnalysisType = PonicsSystemAnalysisType.Warning,
                Title = $"{Context.LevelReading.Type} level not ideal",
                Message = $"A {Context.LevelReading.Type} level of {Context.LevelReading.Value} is not ideal for {Context.Organism.Name}",
            });

            return input;
        }

        public override bool ExecuteCondition()
        {
            return Context.LevelAnalysis.IdealForOrganism && Context.LevelAnalysis.SuitableForOrganism;
        }
    }
}
