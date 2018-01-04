using MongoDB.Driver;
using Ponics.Aquaponics;

namespace Ponics.Data.Mongo.CommandHandlers
{
    public class UpdatePonicsSystemDataCommandHandler : MongoDataCommandHandler<UpdateSystem>
    {
        public UpdatePonicsSystemDataCommandHandler(IMongoDatabase database) : base(database)
        {
        }

        public override void Handle(UpdateSystem command)
        {
            var ponicsSystem = Database.GetCollection<PonicsSystem>(nameof(PonicsSystem));
            ponicsSystem.ReplaceOne(doc => doc.Id == command.SystemId, command.System);
        }
    }
}
