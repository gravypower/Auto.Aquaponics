using System.Collections.Generic;

namespace Ponics.Analysis.PonicsSystem.Pipelines.AnalyseLevels
{
    public class AnalyseLevelsPipelineContext:List<AnalyseLevelsPipelineContextItem>
    {
        public Ponics.PonicsSystem System { get; set; }
    }
}
