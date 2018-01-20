using MongoDB.Driver;
using Ponics.Aquaponics;
using Ponics.Aquaponics.Queries;
using Ponics.Authentication.User;
using Ponics.Authentication.User.Queries;

namespace Ponics.Data.Mongo.QueryHandlers
{
    public class GetUserDataQueryHandler : MongoDataQueryHandler<GetUser, User>
    {
        public GetUserDataQueryHandler(IMongoDatabase database) : base(database)
        {
        }

        public override User Handle(GetUser query)
        {
            var idFilter = Builders<User>.Filter.Eq("_id", query.UserId);
            var typeFilter = Builders<User>.Filter.Eq("_t", typeof(User).Name);
            var users = Database.GetCollection<User>(nameof(User));
            return users
                .Find(idFilter & typeFilter)
                .SingleOrDefault();
        }
    }
}
