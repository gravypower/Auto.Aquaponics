using MongoDB.Driver;
using Ponics.AquaponicSystems;

namespace Ponics.Data.Mongo.CommandHandlers
{
    public class UpdateSystemDataCommandHandler : MongoDataCommandHandler<UpdateSystem>
    {
        public UpdateSystemDataCommandHandler(IMongoDatabase database) : base(database)
        {
        }

        public override void Handle(UpdateSystem command)
        {
            var aquaponicSystems = Database.GetCollection<AquaponicSystem>(nameof(AquaponicSystem));
            aquaponicSystems.ReplaceOne(doc => doc.Id == command.Id, command.System);
        }
    }
}
