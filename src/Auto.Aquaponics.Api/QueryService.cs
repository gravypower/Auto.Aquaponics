using ServiceStack;

namespace Auto.Aquaponics.Api
{
    public abstract class QueryService : Service
    {
        public virtual object Exec<TQuery>(dynamic query)
        {
            var queryHandler = Bootstrapper.GetQueryHandler(query.GetType());

            return queryHandler.Handle(query);
        }
    }
}
