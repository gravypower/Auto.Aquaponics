using MongoDB.Driver;
using Ponics.Commands;

namespace Ponics.Data.Mongo.CommandHandlers
{
    class AddLevelReadingDataCommandHandler : MongoDataCommandHandler<AddLevelReading>
    {
        public AddLevelReadingDataCommandHandler(IMongoDatabase database) : base(database)
        {
        }

        public override void Handle(AddLevelReading command)
        {
            var idFilter = Builders<PonicsSystem>.Filter.Eq("_id", command.SystemId);
            var ponicsSystem = Database.GetCollection<PonicsSystem>(nameof(PonicsSystem));

            var update = Builders<PonicsSystem>.Update.PushEach(s => s.LevelReadings, command.LevelReadings);
            ponicsSystem.UpdateOne(idFilter, update);
        }
    }
}
