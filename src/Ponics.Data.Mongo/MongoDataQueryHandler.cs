using MongoDB.Driver;
using Ponics.Kernel.Queries;

namespace Ponics.Data.Mongo
{
    public abstract class MongoDataQueryHandler<TDataQuery, TDataResponce, TDocumentCollection> : 
        MongoHandler, 
        IDataQueryHandler<TDataQuery, TDataResponce> 
        where TDataQuery : IDataQuery<TDataResponce>
    {
        protected MongoDataQueryHandler(IMongoDatabase database) : base(database)
        {
        }

        public abstract FilterDefinition<TDocumentCollection> BuildFilterDefinition(TDataQuery query);

        public abstract TDataResponce DoHandle(TDataQuery query, IMongoCollection<TDocumentCollection> collection, FilterDefinition<TDocumentCollection> filterDefinition);

        public TDataResponce Handle(TDataQuery query)
        {
            var collection = Database.GetCollection<TDocumentCollection>(nameof(TDocumentCollection));
            return DoHandle(query, collection, BuildFilterDefinition(query));
        }
    }
}
