using System;
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
            throw new NotImplementedException();
        }
    }
}
