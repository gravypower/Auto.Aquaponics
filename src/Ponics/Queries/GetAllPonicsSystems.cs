using System.Collections.Generic;
using Ponics.Kernel.Queries;

namespace Ponics.Queries
{
    public abstract class GetAllPonicsSystems<TPonicsSystem> : IQuery<List<TPonicsSystem>>, IDataQuery<List<TPonicsSystem>>
        where TPonicsSystem : PonicsSystem
    {
    }
}
