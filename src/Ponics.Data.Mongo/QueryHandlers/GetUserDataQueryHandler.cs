using MongoDB.Driver;
using Ponics.Authentication.Users;

namespace Ponics.Data.Mongo.QueryHandlers
{
    public class GetUserDataQueryHandler : MongoDataQueryHandler<GetUser, User, User>
    {
        public GetUserDataQueryHandler(IMongoDatabase database) : base(database)
        {
        }

        public override FilterDefinition<User> BuildFilterDefinition(GetUser query)
        {
            return Builders<User>.Filter.Eq("_id", query.UserId);
        }

        public override User DoHandle(GetUser query, IMongoCollection<User> collection, FilterDefinition<User> filterDefinition)
        {
            return collection
                .Find(filterDefinition)
                .SingleOrDefault();
        }
    }
}