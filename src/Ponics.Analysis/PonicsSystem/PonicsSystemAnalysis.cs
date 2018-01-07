using System.Collections.Generic;

namespace Ponics.Analysis.PonicsSystem
{
    public class PonicsSystemAnalysis : List<PonicsSystemAnalysisItem>
    {
    }

    public class PonicsSystemAnalysisItem
    {
        public PonicsSystemAnalysisType PonicsSystemAnalysisType { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
    }
}
