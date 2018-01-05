using System.Collections.Generic;
using Ponics.Kernel.Pipelines;

namespace Ponics.Analysis.PonicsSystem.Pipelines.AnalyseLevels
{
    public class AnalyseLevelsPipeline:Pipeline<Node<PonicsSystemAnalysis, AnalyseLevelsPipelineContext>, PonicsSystemAnalysis, AnalyseLevelsPipelineContext>
    {
        public AnalyseLevelsPipeline(IEnumerable<Node<PonicsSystemAnalysis, AnalyseLevelsPipelineContext>> nodes) : base(nodes)
        {
        }
    }
}
