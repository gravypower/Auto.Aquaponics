using MongoDB.Driver;
using Ponics.Aquaponics;
using Ponics.Aquaponics.Queries;

namespace Ponics.Data.Mongo.QueryHandlers
{
    public class GetSystemDataQueryHandler : MongoDataQueryHandler<GetSystem, AquaponicSystem>
    {
        public GetSystemDataQueryHandler(IMongoDatabase database) : base(database)
        {
        }

        public override AquaponicSystem Handle(GetSystem query)
        {
            var idFilter = Builders<AquaponicSystem>.Filter.Eq("_id", query.SystemId);
            var typeFilter = Builders<AquaponicSystem>.Filter.Eq("_t", typeof(AquaponicSystem).Name);
            var aquaponicSystem = Database.GetCollection<AquaponicSystem>(nameof(PonicsSystem));
            return aquaponicSystem
                .Find(idFilter & typeFilter)
                .SingleOrDefault();
        }
    }
}
