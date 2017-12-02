using MongoDB.Driver;
using Ponics.Organisms;

namespace Ponics.Data.Mongo.CommandHandlers
{
    public class AddOrganismDataCommandHandler : MongoDataCommandHandler<AddOrganism>
    {
        public AddOrganismDataCommandHandler(IMongoDatabase database) : base(database)
        {
        }

        public override void Handle(AddOrganism command)
        {
            var organisms = Database.GetCollection<Organism>(nameof(Organism));
            organisms.InsertOneAsync(command.Organism);
        }
    }
}