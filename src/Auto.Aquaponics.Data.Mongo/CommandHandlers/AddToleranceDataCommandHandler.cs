using Auto.Aquaponics.Analysis.Levels;
using Auto.Aquaponics.Organisms;
using MongoDB.Driver;

namespace Auto.Aquaponics.Data.Mongo.CommandHandlers
{
    public class AddToleranceDataCommandHandler<TTolerance> : MongoDataCommandHandler<AddTolerance<TTolerance>>
        where TTolerance : Tolerance
    {
        public AddToleranceDataCommandHandler(IMongoDatabase database) : base(database)
        {
        }

        public override void Handle(AddTolerance<TTolerance> command)
        {
            var filter = Builders<Organism>.Filter.Eq("_id", command.OrganismId);
            var organisms = Database.GetCollection<Organism>(nameof(Organism));
            var organism = organisms.Find(filter).SingleOrDefault();

            organism.Tolerances.Add(command.Tolerance);

            var update = Builders<Organism>.Update.Set(nameof(Organism.Tolerances), organism.Tolerances);
            organisms.UpdateOne(filter, update);

        }
    }
}
