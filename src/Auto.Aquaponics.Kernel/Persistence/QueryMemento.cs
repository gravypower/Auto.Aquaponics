using Auto.Aquaponics.Kernel.Query;

namespace Auto.Aquaponics.Kernel.Persistence
{
    public abstract class QueryMemento : IMemento<Query<QueryResult>>
    {
        public void Save(Query<QueryResult> query)
        {
            Save(query.GetType().FullName, "", query);
        }

        public abstract void Save(string type, string key, Query<QueryResult> data);

        public abstract T Load<T>(string fullName, string key);
    }
}
