using MongoDB.Driver;
using Ponics.Organisms;
using Ponics.Organisms.Commands;

namespace Ponics.Data.Mongo.CommandHandlers
{
    public class DeleteOrganismDataCommandHandler : MongoDataCommandHandler<DeleteOrganism>
    {
        public DeleteOrganismDataCommandHandler(IMongoDatabase database) : base(database)
        {
        }

        public override void Handle(DeleteOrganism command)
        { 
            var organisms = Database.GetCollection<Organism>(nameof(Organism));
            organisms.DeleteOne(doc => doc.Id == command.OrganismId);
        }
    }
}
