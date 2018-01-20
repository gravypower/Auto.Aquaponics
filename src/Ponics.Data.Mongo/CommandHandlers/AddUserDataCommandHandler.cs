using MongoDB.Driver;
using Ponics.Authentication.User;

namespace Ponics.Data.Mongo.CommandHandlers
{
    public class AddUserDataCommandHandler : MongoDataCommandHandler<AddUser>
    {
        public AddUserDataCommandHandler(IMongoDatabase database) : base(database)
        {
        }

        public override void Handle(AddUser command)
        {
            var organisms = Database.GetCollection<User>(nameof(User));
            organisms.InsertOneAsync(command.User);
        }
    }
}
