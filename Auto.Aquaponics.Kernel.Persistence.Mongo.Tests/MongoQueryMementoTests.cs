using Auto.Aquaponics.Kernel.Tests.Query;
using MongoDB.Bson;
using MongoDB.Driver;
using NSubstitute;
using NUnit.Framework;

namespace Auto.Aquaponics.Kernel.Persistence.Mongo.Tests
{
    [TestFixture]
    public class MongoQueryMementoTests
    {
        public MongoQueryMemento Sut;
        public IMongoDatabase MongoDatabase;

        [SetUp]
        public void SetUp()
        {
            MongoDatabase = Substitute.For<IMongoDatabase>();
            Sut = new MongoQueryMemento(MongoDatabase);
        }

       
    }
}
