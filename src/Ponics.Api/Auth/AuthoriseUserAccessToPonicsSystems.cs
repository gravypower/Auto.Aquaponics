using System.Collections.Generic;
using Ponics.Authentication.Users;
using Ponics.Kernel.Queries;
using Ponics.Queries;

namespace Ponics.Api.Auth
{
    public class AuthoriseUserAccessToPonicsSystems<TGetAllPonicsSystem, TPonicsSystem> : IDataQueryHandler<TGetAllPonicsSystem, List<TPonicsSystem>>
        where TPonicsSystem : PonicsSystem
        where TGetAllPonicsSystem : GetAllPonicsSystems<TPonicsSystem>
    {
        private readonly IQueryHandler<TGetAllPonicsSystem, List<TPonicsSystem>> _decorated;
        private readonly IDataQueryHandler<GetUser, User> _getUserDataQueryHandler;

        public AuthoriseUserAccessToPonicsSystems(
            IQueryHandler<TGetAllPonicsSystem, List<TPonicsSystem>> decorated,
            IDataQueryHandler<GetUser, User> getUserDataQueryHandler)
        {
            _decorated = decorated;
            _getUserDataQueryHandler = getUserDataQueryHandler;
        }

        public List<TPonicsSystem> Handle(TGetAllPonicsSystem query)
        {
            var user = _getUserDataQueryHandler.Handle(new GetUser {UserId = Context.UserId}); 


            return _decorated.Handle(query);
        }
    }
}