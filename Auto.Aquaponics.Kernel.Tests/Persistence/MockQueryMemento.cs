using System.Collections.Generic;
using Auto.Aquaponics.Kernel.Persistence;

namespace Auto.Aquaponics.Kernel.Tests.Persistence
{
    public class MockQueryMemento: QueryMemento
    {
        public 
            Dictionary<string, IDictionary<string, 
            IDictionary<string, object>>> Persistence = new Dictionary<string, IDictionary<string, IDictionary<string, object>>>();

        public override void Save(string systemKey, string type, string key, Kernel.Query.Query data)
        {
            if (!Persistence.ContainsKey(type))
            {
                Persistence.Add(systemKey, new Dictionary<string, IDictionary<string, object>>());
            }

            if (!Persistence[systemKey].ContainsKey(type))
            {
                Persistence[systemKey].Add(type, new Dictionary<string, object>());
            }

            Persistence[systemKey][type].Add(key, data);
        }

        public override T Load<T>(string systemKey, string type, string key)
        {
            return (T) Persistence[systemKey][type][key];
        }
    }
}
