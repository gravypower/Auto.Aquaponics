using MongoDB.Driver;
using Ponics.Aquaponics.Commands;

namespace Ponics.Data.Mongo.CommandHandlers
{
    public class AddPonicsSystemDataCommandHandler : MongoDataCommandHandler<AddAquaponicSystem>
    {
        public AddPonicsSystemDataCommandHandler(IMongoDatabase database) : base(database)
        {
        }

        public override void Handle(AddAquaponicSystem command)
        {
            var organisms = Database.GetCollection<PonicsSystem>(nameof(PonicsSystem));
            organisms.InsertOneAsync(command.System);
        }
    }
}
