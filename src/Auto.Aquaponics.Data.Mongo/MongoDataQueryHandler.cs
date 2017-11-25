using Auto.Aquaponics.Kernel.Data;
using MongoDB.Driver;

namespace Auto.Aquaponics.Data.Mongo
{
    public abstract class MongoDataQueryHandler<TDataQuery, TDataResponce> : 
        MongoHandler, 
        IDataQueryHandler<TDataQuery, TDataResponce> 
        where TDataQuery : IDataQuery<TDataResponce>
    {
        protected MongoDataQueryHandler(IMongoDatabase database) : base(database)
        {
        }

        public abstract TDataResponce Handle(TDataQuery query);
    }
}
