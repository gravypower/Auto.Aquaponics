namespace Auto.Aquaponics.Kernel.Tests.Query
{
    public class MockQuery:Kernel.Query.Query
    {
        public override string Key { get; }

        public MockQuery()
        { }

        public MockQuery(string key)
        {
            Key = key;
        }

        
    }
}
