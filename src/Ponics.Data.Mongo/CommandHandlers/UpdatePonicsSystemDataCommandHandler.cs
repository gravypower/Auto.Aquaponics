using MongoDB.Driver;
using Ponics.Aquaponics.Commands;

namespace Ponics.Data.Mongo.CommandHandlers
{
    public class UpdatePonicsSystemDataCommandHandler : MongoDataCommandHandler<UpdateAquaponicSystem>
    {
        public UpdatePonicsSystemDataCommandHandler(IMongoDatabase database) : base(database)
        {
        }

        public override void Handle(UpdateAquaponicSystem command)
        {
            var ponicsSystem = Database.GetCollection<PonicsSystem>(nameof(PonicsSystem));
            ponicsSystem.ReplaceOne(doc => doc.Id == command.SystemId, command.System);
        }
    }
}
