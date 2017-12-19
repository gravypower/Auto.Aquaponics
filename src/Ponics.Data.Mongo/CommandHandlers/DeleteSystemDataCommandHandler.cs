using MongoDB.Driver;
using Ponics.AquaponicSystems;

namespace Ponics.Data.Mongo.CommandHandlers
{
    public class DeleteSystemDataCommandHandler : MongoDataCommandHandler<DeleteSystem>
    {
        public DeleteSystemDataCommandHandler(IMongoDatabase database) : base(database)
        {
        }

        public override void Handle(DeleteSystem command)
        {
            var aquaponicSystems = Database.GetCollection<AquaponicSystem>(nameof(AquaponicSystem));
            aquaponicSystems.DeleteOne(doc => doc.Id == command.Id);

        }
    }
}
