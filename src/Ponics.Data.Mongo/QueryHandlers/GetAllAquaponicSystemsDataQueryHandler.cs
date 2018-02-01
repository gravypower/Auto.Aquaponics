using System.Collections.Generic;
using MongoDB.Driver;
using Ponics.Aquaponics;
using Ponics.Aquaponics.Queries;

namespace Ponics.Data.Mongo.QueryHandlers
{
    public class GetAllAquaponicSystemsDataQueryHandler : MongoDataQueryHandler<GetAllAquaponicSystems, List<AquaponicSystem>, AquaponicSystem>
    {
        public GetAllAquaponicSystemsDataQueryHandler(IMongoDatabase database) : base(database)
        {
        }

        public override FilterDefinition<AquaponicSystem> BuildFilterDefinition(GetAllAquaponicSystems query)
        {
            return Builders<AquaponicSystem>.Filter.Eq("_t", typeof(AquaponicSystem).Name);
        }

        public override List<AquaponicSystem> DoHandle(GetAllAquaponicSystems query, IMongoCollection<AquaponicSystem> collection, FilterDefinition<AquaponicSystem> filterDefinition)
        {
            return Database.GetCollection<AquaponicSystem>(nameof(PonicsSystem))
                .Find(filterDefinition).ToList();
        }
    }
}
