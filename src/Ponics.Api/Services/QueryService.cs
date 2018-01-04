using System.Threading;
using Ponics.Api.CompositionRoot;
using Ponics.Kernel.Queries;
using Ponics.Queries;
using ServiceStack;

namespace Ponics.Api.Services
{
    public abstract class QueryService : Service
    {
        public virtual TResult Exec<TQuery, TResult>(TQuery query) where TQuery : Query<TResult>
        {
#if DEBUG
            Thread.Sleep(500);
#endif
            var queryHandler = Bootstrapper.GetQueryHandler(query.GetType()) as IQueryHandler<TQuery, TResult>;

            return queryHandler.Handle(query);
        }
    }
}
