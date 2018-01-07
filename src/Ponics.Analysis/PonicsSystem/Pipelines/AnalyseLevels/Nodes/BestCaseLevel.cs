using System;
using System.Collections.Generic;
using Ponics.Kernel.Pipelines;
using Ponics.Kernel.Queries;
using Ponics.Organisms;
using Ponics.Strategies;

namespace Ponics.Analysis.PonicsSystem.Pipelines.AnalyseLevels.Nodes
{
    public class BestCaseLevel : Node<PonicsSystemAnalysis, AnalyseLevelsPipelineContext>
    {
        private readonly IQueryStrategyHandler<GetPonicSystemOrganisms, List<Organism>> _getPonicSystemOrganismsStrategyHandler;

        public BestCaseLevel(IQueryStrategyHandler<GetPonicSystemOrganisms, List<Organism>> getPonicSystemOrganismsStrategyHandler)
        {
            _getPonicSystemOrganismsStrategyHandler = getPonicSystemOrganismsStrategyHandler;
        }

        public override PonicsSystemAnalysis DoExecute(PonicsSystemAnalysis input)
        {
            var organisms = _getPonicSystemOrganismsStrategyHandler.Handle(new GetPonicSystemOrganisms
            {
                SystemId = Context.System.Id
            });

            return input;
        }
    }
}
