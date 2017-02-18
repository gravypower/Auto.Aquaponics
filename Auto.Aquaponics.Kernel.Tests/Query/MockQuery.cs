namespace Auto.Aquaponics.Kernel.Tests.Query
{
    public class MockQuery:Kernel.Query.Query
    {
        public override string Key { get; }
        public override string SystemKey { get; }

        public MockQuery()
        { }

        public MockQuery(string systemKey, string key)
        {
            SystemKey = systemKey;
            Key = key;
        }

        
    }
}
