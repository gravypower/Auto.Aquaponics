using System.Collections.Generic;
using MongoDB.Driver;
using Ponics.Authentication.Users;
using Ponics.Data.Mongo;
using Ponics.Kernel.Queries;
using Ponics.Queries;
using ServiceStack;

namespace Ponics.Api.Auth
{
    public class
        AuthoriseUserAccessToPonicsSystems<TGetAllPonicsSystem, TPonicsSystem> : MongoDataQueryHandler<TGetAllPonicsSystem, List<TPonicsSystem>, TPonicsSystem>
        where TPonicsSystem : PonicsSystem
        where TGetAllPonicsSystem : GetAllPonicsSystems<TPonicsSystem>
    {
        private readonly MongoDataQueryHandler<TGetAllPonicsSystem, List<TPonicsSystem>, TPonicsSystem> _decorated;
        private readonly IDataQueryHandler<GetUser, User> _getUserDataQueryHandler;

        public AuthoriseUserAccessToPonicsSystems(
            IDataQueryHandler<TGetAllPonicsSystem, List<TPonicsSystem>> decorated,
            IDataQueryHandler<GetUser, User> getUserDataQueryHandler,
            IMongoDatabase database) : base(database)
        {
            _decorated = decorated as MongoDataQueryHandler<TGetAllPonicsSystem, List<TPonicsSystem>, TPonicsSystem>;
            _getUserDataQueryHandler = getUserDataQueryHandler;
        }

        public override FilterDefinition<TPonicsSystem> BuildFilterDefinition(TGetAllPonicsSystem query)
        {
            var user = _getUserDataQueryHandler.Handle(new GetUser { UserId = Context.UserId });

            if (user.PonicsSystemIds.Count == 0)
            {
                throw HttpError.NotFound($"No {typeof(TPonicsSystem).Name} found for user");
            }
            var filterDefinition = _decorated.BuildFilterDefinition(query);

            foreach (var userPonicsSystemId in user.PonicsSystemIds)
            {
                filterDefinition = filterDefinition | Builders<TPonicsSystem>.Filter.Eq("_id", userPonicsSystemId);
            }

            return filterDefinition;
        }

        public override List<TPonicsSystem> DoHandle(TGetAllPonicsSystem query, IMongoCollection<TPonicsSystem> collection, FilterDefinition<TPonicsSystem> filterDefinition)
        {
            return _decorated.DoHandle(query, collection, filterDefinition);
        }
    }
}