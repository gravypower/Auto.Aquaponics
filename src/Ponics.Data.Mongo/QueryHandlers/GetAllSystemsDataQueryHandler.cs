using System.Collections.Generic;
using MongoDB.Driver;
using Ponics.Aquaponics;
using Ponics.Aquaponics.Queries;

namespace Ponics.Data.Mongo.QueryHandlers
{
    public class GetAllSystemsDataQueryHandler : MongoDataQueryHandler<GetAllAquaponicSystems, List<AquaponicSystem>>
    {
        public GetAllSystemsDataQueryHandler(IMongoDatabase database) : base(database)
        {
        }

        public override List<AquaponicSystem> Handle(GetAllAquaponicSystems query)
        {
            var typeFilter = Builders<AquaponicSystem>.Filter.Eq("_t", typeof(AquaponicSystem).Name);
            return Database.GetCollection<AquaponicSystem>(nameof(PonicsSystem))
                .Find(typeFilter)
                .ToList();
        }
    }
}
