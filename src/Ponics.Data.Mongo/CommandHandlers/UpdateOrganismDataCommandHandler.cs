using MongoDB.Driver;
using Ponics.Organisms;
using Ponics.Organisms.Commands;

namespace Ponics.Data.Mongo.CommandHandlers
{
    public class UpdateOrganismDataCommandHandler : MongoDataCommandHandler<UpdateOrganism>
    {
        public UpdateOrganismDataCommandHandler(IMongoDatabase database) : base(database)
        {
        }

        public override void Handle(UpdateOrganism command)
        { 
            var organisms = Database.GetCollection<Organism>(nameof(Organism));
            organisms.ReplaceOne(doc => doc.Id == command.OrganismId, command.Organism);
        }
    }
}
