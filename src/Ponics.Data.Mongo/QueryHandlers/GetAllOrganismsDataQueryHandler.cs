using System.Collections.Generic;
using MongoDB.Driver;
using Ponics.Organisms;

namespace Ponics.Data.Mongo.QueryHandlers
{
    public class GetAllOrganismsDataQueryHandler:
        MongoDataQueryHandler<GetOrganisms, List<Organism>>
    {
        public GetAllOrganismsDataQueryHandler(IMongoDatabase database) : base(database)
        {
        }

        public override List<Organism> Handle(GetOrganisms query)
        {
            return 
                Database.GetCollection<Organism>(nameof(Organism))
                .AsQueryable()
                .ToList();
        }
    }
}
