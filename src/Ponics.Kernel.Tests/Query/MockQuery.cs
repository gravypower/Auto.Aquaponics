using Ponics.Kernel.Queries;
using Ponics.Queries;

namespace Ponics.Kernel.Tests.Query
{
    public class MockQuery:IQuery<MockQueryResult>
    {
        public MockQuery()
        { }

        public MockQuery(string key)
        { }   
    }
}
