using System.Collections.Generic;
using Auto.Aquaponics.Organisms;
using MongoDB.Driver;

namespace Auto.Aquaponics.Data.Mongo
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
