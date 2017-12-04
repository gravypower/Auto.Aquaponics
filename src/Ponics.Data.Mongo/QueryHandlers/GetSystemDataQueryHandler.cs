using MongoDB.Driver;
using Ponics.AquaponicSystems;

namespace Ponics.Data.Mongo.QueryHandlers
{
    public class GetSystemDataQueryHandler : MongoDataQueryHandler<GetSystem, AquaponicSystem>
    {
        public GetSystemDataQueryHandler(IMongoDatabase database) : base(database)
        {
        }

        public override AquaponicSystem Handle(GetSystem query)
        {
            var filter = Builders<AquaponicSystem>.Filter.Eq("_id", query.Id);
            var aquaponicSystem = Database.GetCollection<AquaponicSystem>(nameof(AquaponicSystem));
            return aquaponicSystem.Find(filter).SingleOrDefault();
        }
    }
}
