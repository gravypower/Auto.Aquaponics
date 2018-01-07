using System.Linq;
using Ponics.Kernel.Pipelines;

namespace Ponics.Analysis.PonicsSystem.Pipelines.AnalyseLevels.Nodes
{
    public class NotSuitableForOrganism: Node<PonicsSystemAnalysis, AnalyseLevelsPipelineContext>
    {
        public override PonicsSystemAnalysis DoExecute(PonicsSystemAnalysis input)
        {
            input.AddRange(
                from item in Context
                where !item.LevelAnalysis.SuitableForOrganism
                select new PonicsSystemAnalysisItem
                {
                    PonicsSystemAnalysisType = PonicsSystemAnalysisType.Error,
                    Title = $"{item.LevelReading.Type} level not suitable!",
                    Message = $"A {item.LevelReading.Type} level of {item.LevelReading.Value} is not Suitable for {item.Organism.Name}",
                });

            return input;
        }
    }
}
