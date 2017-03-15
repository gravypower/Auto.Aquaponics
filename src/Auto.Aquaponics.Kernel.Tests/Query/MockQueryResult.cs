using Auto.Aquaponics.Kernel.Query;

namespace Auto.Aquaponics.Kernel.Tests.Query
{
    public class MockQueryResult:QueryResult
    {
        public Query<QueryResult> Query { get; set; }

    }
}
