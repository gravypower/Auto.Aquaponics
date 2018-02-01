using MongoDB.Driver;
using Ponics.Aquaponics;
using Ponics.Aquaponics.Queries;

namespace Ponics.Data.Mongo.QueryHandlers
{
    public class GetAquaponicSystemDataQueryHandler : MongoDataQueryHandler<GetAquaponicSystem, AquaponicSystem, AquaponicSystem>
    {
        public GetAquaponicSystemDataQueryHandler(IMongoDatabase database) : base(database)
        {
        }

        public override FilterDefinition<AquaponicSystem> BuildFilterDefinition(GetAquaponicSystem query)
        {
            var idFilter = Builders<AquaponicSystem>.Filter.Eq("_id", query.SystemId);
            var typeFilter = Builders<AquaponicSystem>.Filter.Eq("_t", typeof(AquaponicSystem).Name);

            return idFilter & typeFilter;
        }

        public override AquaponicSystem DoHandle(GetAquaponicSystem query, IMongoCollection<AquaponicSystem> collection, FilterDefinition<AquaponicSystem> filterDefinition)
        {
            var aquaponicSystems = Database.GetCollection<AquaponicSystem>(nameof(PonicsSystem));
            return aquaponicSystems
                .Find(filterDefinition)
                .SingleOrDefault();
        }
    }
}
