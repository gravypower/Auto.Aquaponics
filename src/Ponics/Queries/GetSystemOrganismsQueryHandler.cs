using System.Collections.Generic;
using Ponics.Kernel.Queries;
using Ponics.Organisms;
using Ponics.Strategies;
using Ponics.Strategies.Queries;

namespace Ponics.Queries
{
    public class GetSystemOrganismsQueryHandler : IQueryHandler<GetSystemOrganisms, List<Organism>>
    {
        private readonly IQueryStrategyHandler<GetPonicSystemOrganisms, List<Organism>> _getPonicSystemOrganismsStrategyHandler;

        public GetSystemOrganismsQueryHandler(
            IQueryStrategyHandler<GetPonicSystemOrganisms, List<Organism>> getPonicSystemOrganismsStrategyHandler
            )
        {
            _getPonicSystemOrganismsStrategyHandler = getPonicSystemOrganismsStrategyHandler;
        }

        public List<Organism> Handle(GetSystemOrganisms query)
        {
            return _getPonicSystemOrganismsStrategyHandler.Handle(new GetPonicSystemOrganisms {SystemId = query.SystemId});
        }
    }
}
