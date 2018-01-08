using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Ponics.Kernel.Pipelines;
using Ponics.Kernel.Queries;
using Ponics.Organisms;
using Ponics.Strategies;

namespace Ponics.Analysis.PonicsSystem.Pipelines.AnalyseLevels.Nodes
{
    public class BestCaseLevel : Node<PonicsSystemAnalysis, AnalyseLevelsPipelineContext>
    {
        private readonly IQueryStrategyHandler<GetPonicSystemOrganisms, List<Organism>> _getPonicSystemOrganismsStrategyHandler;
        private Dictionary<string, List<double>> _upper;
        private Dictionary<string, List<double>> _lower;
        private Dictionary<string, List<double>> _desiredLower;
        private Dictionary<string, List<double>> _desiredUpper;

        public BestCaseLevel(IQueryStrategyHandler<GetPonicSystemOrganisms, List<Organism>> getPonicSystemOrganismsStrategyHandler)
        {
            _getPonicSystemOrganismsStrategyHandler = getPonicSystemOrganismsStrategyHandler;

            _upper = new Dictionary<string, List<double>>();
            _lower = new Dictionary<string, List<double>>();
            _desiredLower = new Dictionary<string, List<double>>();
            _desiredUpper = new Dictionary<string, List<double>>();
        }

        public override PonicsSystemAnalysis DoExecute(PonicsSystemAnalysis input)
        {

            return input;

            var organisms = _getPonicSystemOrganismsStrategyHandler.Handle(new GetPonicSystemOrganisms
            {
                SystemId = Context.System.Id
            });

            foreach (var organism in organisms)
            {
                foreach (var tolerance in organism.Tolerances)
                {
                    AddTolerance(_upper, tolerance.Type, tolerance.Upper);
                    AddTolerance(_lower, tolerance.Type, tolerance.Lower);
                    AddTolerance(_desiredLower, tolerance.Type, tolerance.DesiredLower);
                    AddTolerance(_desiredUpper, tolerance.Type, tolerance.Upper);
                }
            }

            
            




            return input;
        }

        private static void AddTolerance(IDictionary<string, List<double>> tolerances, string type, double value)
        {
            tolerances[type].Add(value);
        }
    }
}
