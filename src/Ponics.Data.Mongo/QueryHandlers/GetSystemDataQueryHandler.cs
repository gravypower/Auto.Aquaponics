using MongoDB.Driver;
using Ponics.Aquaponics;
using Ponics.Aquaponics.Queries;

namespace Ponics.Data.Mongo.QueryHandlers
{
    public class GetSystemDataQueryHandler : MongoDataQueryHandler<GetAquaponicSystem, AquaponicSystem>
    {
        public GetSystemDataQueryHandler(IMongoDatabase database) : base(database)
        {
        }

        public override AquaponicSystem Handle(GetAquaponicSystem query)
        {
            var idFilter = Builders<AquaponicSystem>.Filter.Eq("_id", query.SystemId);
            var typeFilter = Builders<AquaponicSystem>.Filter.Eq("_t", typeof(AquaponicSystem).Name);
            var aquaponicSystems = Database.GetCollection<AquaponicSystem>(nameof(PonicsSystem));
            return aquaponicSystems
                .Find(idFilter & typeFilter)
                .SingleOrDefault();
        }
    }
}
