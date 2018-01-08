using System.Collections.Generic;

namespace Ponics.Analysis.PonicsSystem
{
    public class PonicsSystemAnalysis
    {
        public List<PonicsSystemAnalysisItem> Items { get; set; }

        public PonicsSystemAnalysis()
        {
            Items = new List<PonicsSystemAnalysisItem>();
        }
    }

    public class PonicsSystemAnalysisItem
    {
        public PonicsSystemAnalysisType PonicsSystemAnalysisType { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
    }
}
