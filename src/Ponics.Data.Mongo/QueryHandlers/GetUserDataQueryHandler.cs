using MongoDB.Driver;
using Ponics.Data.Users;

namespace Ponics.Data.Mongo.QueryHandlers
{
    public class GetUserDataQueryHandler : MongoDataQueryHandler<GetUser, User, User>
    {
        public GetUserDataQueryHandler(IMongoDatabase database) : base(database)
        {
        }

        public override FilterDefinition<User> BuildFilterDefinition(GetUser query)
        {
            var idFilter = Builders<User>.Filter.Eq("_id", query.UserId);
            var typeFilter = Builders<User>.Filter.Eq("_t", typeof(User).Name);

            return idFilter & typeFilter;
        }

        public override User DoHandle(GetUser query, IMongoCollection<User> collection, FilterDefinition<User> filterDefinition)
        {
            return collection
                .Find(filterDefinition)
                .SingleOrDefault();
        }
    }
}