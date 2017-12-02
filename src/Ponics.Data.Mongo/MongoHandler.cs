using MongoDB.Driver;

namespace Ponics.Data.Mongo
{
    public abstract class MongoHandler
    {
        protected readonly IMongoDatabase Database;

        protected MongoHandler(IMongoDatabase database)
        {
            Database = database;
        }
    }
}