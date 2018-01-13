using MongoDB.Driver;
using Ponics.Aquaponics.Commands;

namespace Ponics.Data.Mongo.CommandHandlers
{
    public class DeletePonicsSystemDataCommandHandler : MongoDataCommandHandler<DeleteSystem>
    {
        public DeletePonicsSystemDataCommandHandler(IMongoDatabase database) : base(database)
        {
        }

        public override void Handle(DeleteSystem command)
        {
            var aquaponicSystems = Database.GetCollection<PonicsSystem>(nameof(PonicsSystem));
            aquaponicSystems.DeleteOne(doc => doc.Id == command.SystemId);

        }
    }
}
