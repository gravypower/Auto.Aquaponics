using MongoDB.Bson;
using MongoDB.Driver;

namespace Auto.Aquaponics.Kernel.Persistence.Mongo
{
    public class MongoQueryMemento: QueryMemento
    {
        private readonly IMongoDatabase _database;

        public MongoQueryMemento(IMongoDatabase database)
        {
            _database = database;
        }
        public override void Save(string type, string key, Query.Query data)
        {
            _database.CreateCollection(type);
            var collection = _database.GetCollection<BsonDocument>(type);
            collection.InsertOneAsync(data.ToBsonDocument());
        }

        public override T Load<T>(string fullName, string key)
        {
            throw new System.NotImplementedException();
        }
    }
}
