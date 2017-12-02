using System.Collections.Generic;

namespace Ponics.Data.Seed
{
    public abstract class SeedData<TSeedType>
    {
        public string SeedFor => nameof(TSeedType);
        public abstract IEnumerable<TSeedType> GetSeedData();
    }
}
