using MongoDB.Driver;
using Ponics.AquaponicSystems;

namespace Ponics.Data.Mongo.CommandHandlers
{
    public class AddSystemDataCommandHandler : MongoDataCommandHandler<AddSystem>
    {
        public AddSystemDataCommandHandler(IMongoDatabase database) : base(database)
        {
        }

        public override void Handle(AddSystem command)
        {
            var organisms = Database.GetCollection<AquaponicSystem>(nameof(AquaponicSystem));
            organisms.InsertOneAsync(command.System);
        }
    }
}
