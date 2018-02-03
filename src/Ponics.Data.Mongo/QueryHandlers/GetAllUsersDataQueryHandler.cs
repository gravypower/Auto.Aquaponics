using System.Collections.Generic;
using MongoDB.Driver;
using Ponics.Authentication.Users;

namespace Ponics.Data.Mongo.QueryHandlers
{
    public class GetAllUsersDataQueryHandler : MongoDataQueryHandler<AllGetUsers, List<User>, User>
    {
        public GetAllUsersDataQueryHandler(IMongoDatabase database) : base(database)
        {
        }

        public override FilterDefinition<User> BuildFilterDefinition(AllGetUsers query)
        {
            return null;
        }

        public override List<User> DoHandle(AllGetUsers query, IMongoCollection<User> collection, FilterDefinition<User> filterDefinition)
        {
            return collection.AsQueryable().ToList();
        }
    }
}
