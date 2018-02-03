using MongoDB.Driver;
using Ponics.Authentication.Users;

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
            var user = new User {Id = command.UserId};
            organisms.InsertOneAsync(user);
        }
    }
}