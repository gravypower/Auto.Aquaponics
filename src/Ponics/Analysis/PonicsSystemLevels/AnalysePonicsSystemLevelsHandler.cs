using Ponics.Kernel.Queries;
using Ponics.Queries;

namespace Ponics.Analysis.PonicsSystemLevels
{
    public class AnalysePonicsSystemLevelsHandler : IQueryHandler<AnalysePonicsSystemLevels, PonicsSystemLevelsAnalysis>
    {

        public AnalysePonicsSystemLevelsHandler()
        {
        }

        public PonicsSystemLevelsAnalysis Handle(AnalysePonicsSystemLevels query)
        {
            var result = new PonicsSystemLevelsAnalysis();
           



            return result;
        }
    }
}
