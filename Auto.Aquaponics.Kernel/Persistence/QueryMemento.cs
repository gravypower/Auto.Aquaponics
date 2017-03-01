namespace Auto.Aquaponics.Kernel.Persistence
{
    public abstract class QueryMemento : IMemento<Query.Query>
    {
        public void Save(Query.Query query)
        {
            Save(query.GetType().FullName, query.Key, query);
        }

        public abstract void Save(string type, string key, Query.Query data);

        public abstract T Load<T>(string fullName, string key);
    }
}
