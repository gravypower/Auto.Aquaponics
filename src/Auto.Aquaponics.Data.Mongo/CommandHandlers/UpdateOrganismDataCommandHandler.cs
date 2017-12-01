using Auto.Aquaponics.Organisms;
using MongoDB.Driver;

namespace Auto.Aquaponics.Data.Mongo.CommandHandlers
{
    public class UpdateOrganismDataCommandHandler : MongoDataCommandHandler<UpdateOrganism>
    {
        public UpdateOrganismDataCommandHandler(IMongoDatabase database) : base(database)
        {
        }

        public override void Handle(UpdateOrganism command)
        { 
            var filter = Builders<Organism>.Filter.Eq("_id", command.Id);
            var organisms = Database.GetCollection<Organism>(nameof(Organism));
            var update = Builders<Organism>.Update.Set(nameof(Organism), command.Organism);
            organisms.UpdateOne(filter, update);
        }
    }
}
