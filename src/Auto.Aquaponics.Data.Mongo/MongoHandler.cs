using MongoDB.Driver;

namespace Auto.Aquaponics.Data.Mongo
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
