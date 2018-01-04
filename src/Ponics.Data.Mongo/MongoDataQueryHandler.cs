using MongoDB.Driver;
using Ponics.Kernel.Queries;

namespace Ponics.Data.Mongo
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
