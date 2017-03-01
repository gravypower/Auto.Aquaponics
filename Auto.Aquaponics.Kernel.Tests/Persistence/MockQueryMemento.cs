using System.Collections.Generic;
using Auto.Aquaponics.Kernel.Persistence;

namespace Auto.Aquaponics.Kernel.Tests.Persistence
{
    public class MockQueryMemento: QueryMemento
    {
        public 
            Dictionary<string, 
            IDictionary<string, object>> Persistence = new Dictionary<string, IDictionary<string, object>>();

        public override void Save(string type, string key, Kernel.Query.Query data)
        {
            if (!Persistence.ContainsKey(type))
          
            if (!Persistence.ContainsKey(type))
            {
                Persistence.Add(type, new Dictionary<string, object>());
            }

            Persistence[type].Add(key, data);
        }

        public override T Load<T>(string type, string key)
        {
            return (T) Persistence[type][key];
        }
    }
}
