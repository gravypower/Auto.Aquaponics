using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using Ponics.AquaponicSystems;

namespace Ponics.Data.Mongo.QueryHandlers
{
    public class GetAllSystemsHandlerDataQueryHandler : MongoDataQueryHandler<GetAllSystems, IList<AquaponicSystem>>
    {
        public GetAllSystemsHandlerDataQueryHandler(IMongoDatabase database) : base(database)
        {
        }

        public override IList<AquaponicSystem> Handle(GetAllSystems query)
        {
            return Database.GetCollection<AquaponicSystem>(nameof(AquaponicSystem))
                .AsQueryable()
                .ToList();
        }
    }
}
