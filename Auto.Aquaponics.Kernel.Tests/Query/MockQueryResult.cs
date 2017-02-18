using Auto.Aquaponics.Kernel.Query;

namespace Auto.Aquaponics.Kernel.Tests.Query
{
    public class MockQueryResult:QueryResult
    {
        public Kernel.Query.Query Query { get; set; }

    }
}
