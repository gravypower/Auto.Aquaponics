using System.Collections.Generic;
using MongoDB.Driver;
using Ponics.Aquaponics;
using Ponics.Aquaponics.Queries;

namespace Ponics.Data.Mongo.QueryHandlers
{
    public class GetAllAquaponicSystemsDataQueryHandler : MongoDataQueryHandler<GetAllAquaponicSystems, List<AquaponicSystem>>
    {
        public GetAllAquaponicSystemsDataQueryHandler(IMongoDatabase database) : base(database)
        {
        }

        public override List<AquaponicSystem> Handle(GetAllAquaponicSystems query)
        {
            var typeFilter = Builders<AquaponicSystem>.Filter.Eq("_t", typeof(AquaponicSystem).Name);
            var dasta = Database.GetCollection<AquaponicSystem>(nameof(PonicsSystem))
                .Find(typeFilter);
            return dasta.ToList();
        }
    }
}
