using System.Collections.Generic;
using Ponics.Kernel.Queries;

namespace Ponics.Queries
{
    public abstract class GetAllPonicsSystemsQueryHandler<TGetAllPonicsSystem, TPonicsSystem> : IQueryHandler<TGetAllPonicsSystem, List<TPonicsSystem>>
        where TPonicsSystem : PonicsSystem
        where TGetAllPonicsSystem: GetAllPonicsSystems<TPonicsSystem>
    {
        public abstract List<TPonicsSystem> DoHandle(TGetAllPonicsSystem query);

        public List<TPonicsSystem> Handle(TGetAllPonicsSystem query)
        {
            return DoHandle(query);
        }
    }
}
