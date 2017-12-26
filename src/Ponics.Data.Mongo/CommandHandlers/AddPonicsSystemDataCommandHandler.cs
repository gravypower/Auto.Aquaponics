using MongoDB.Driver;
using Ponics.Aquaponics;

namespace Ponics.Data.Mongo.CommandHandlers
{
    public class AddPonicsSystemDataCommandHandler : MongoDataCommandHandler<AddSystem>
    {
        public AddPonicsSystemDataCommandHandler(IMongoDatabase database) : base(database)
        {
        }

        public override void Handle(AddSystem command)
        {
            var organisms = Database.GetCollection<PonicsSystem>(nameof(PonicsSystem));
            organisms.InsertOneAsync(command.System);
        }
    }
}
