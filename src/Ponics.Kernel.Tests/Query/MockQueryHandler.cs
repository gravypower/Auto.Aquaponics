using Ponics.Kernel.Queries;
using Ponics.Queries;

namespace Ponics.Kernel.Tests.Query
{
    internal class MockQueryHandler:IQueryHandler<MockQuery, MockQueryResult>
    {
        public MockQueryResult Handle(MockQuery query)
        {
            return new MockQueryResult();
        }
    }
}
