using System.Collections.Generic;
using MongoDB.Driver;
using Ponics.Organisms;

namespace Ponics.Data.Mongo.QueryHandlers
{
    public class GetAllOrganismsDataQueryHandler:
        MongoDataQueryHandler<GetAllOrganisms, IList<Organism>>
    {
        public GetAllOrganismsDataQueryHandler(IMongoDatabase database) : base(database)
        {
        }

        public override IList<Organism> Handle(GetAllOrganisms query)
        {
            return 
                Database.GetCollection<Organism>(nameof(Organism))
                .AsQueryable()
                .ToList();
        }
    }
}
