using ServiceStack;

namespace Auto.Aquaponics.Api
{
    public abstract class QueryService : Service
    {
        public virtual object Exec<TQuery, TResult>(TQuery query) where TQuery : Query.IQuery<TResult>
        {
            var queryHandler = Bootstrapper.GetQueryHandler<TQuery, TResult>();

            return queryHandler.Handle(query);
        }
    }
}
