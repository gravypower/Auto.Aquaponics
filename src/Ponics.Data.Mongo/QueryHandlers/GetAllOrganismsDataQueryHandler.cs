using System.Collections.Generic;
using MongoDB.Driver;
using Ponics.Organisms;
using Ponics.Organisms.Queries;

namespace Ponics.Data.Mongo.QueryHandlers
{
    public class GetAllOrganismsDataQueryHandler:
        MongoDataQueryHandler<GetOrganisms, List<Organism>, Organism>
    {
        public GetAllOrganismsDataQueryHandler(IMongoDatabase database) : base(database)
        {
        }

        public override FilterDefinition<Organism> BuildFilterDefinition(GetOrganisms query)
        {
            return null;
        }

        public override List<Organism> DoHandle(GetOrganisms query, IMongoCollection<Organism> collection, FilterDefinition<Organism> filterDefinition)
        {
            return collection.AsQueryable().ToList();
        }
    }
}
