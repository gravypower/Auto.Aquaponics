using Auto.Aquaponics.Kernel.Query;

namespace Auto.Aquaponics.Kernel.Tests.Query
{
    internal class MockQueryHandler:IQueryHandler<MockQuery, MockQueryResult>
    {
        public MockQueryResult Handle(MockQuery query)
        {
            return new MockQueryResult();
        }
    }
}
