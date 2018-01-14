using System.Linq;
using Ponics.Kernel.Pipelines;

namespace Ponics.Analysis.PonicsSystem.Pipelines.AnalyseLevels.Nodes
{
    public class NotIdealForOrganism: Node<PonicsSystemAnalysis, AnalyseLevelsPipelineContext>
    {
        public override PonicsSystemAnalysis DoExecute(PonicsSystemAnalysis input)
        {
            input.Items.AddRange(
                from item in Context
                where !item.LevelAnalysis.IdealForOrganism && item.LevelAnalysis.SuitableForOrganism
                select new PonicsSystemAnalysisItem
                {
                    PonicsSystemAnalysisType = PonicsSystemAnalysisType.Warning,
                    Title = $"{item.LevelReading.Type} level not ideal",
                    Message = $"A {item.LevelReading.Type} level of {item.LevelReading.Value} is not ideal for {item.Organism.Name}",
                });

            return input;
        }
    }
}
