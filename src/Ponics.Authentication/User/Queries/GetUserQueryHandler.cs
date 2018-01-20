using Ponics.Kernel.Queries;

namespace Ponics.Authentication.User.Queries
{
    public class GetUserQueryHandler : IQueryHandler<GetUser, User>
    {
        private readonly IDataQueryHandler<GetUser, User> _getUserDataQueryHandler;

        public GetUserQueryHandler(IDataQueryHandler<GetUser, User> getUserDataQueryHandler)
        {
            _getUserDataQueryHandler = getUserDataQueryHandler;
        }
        public User Handle(GetUser query)
        {
            return _getUserDataQueryHandler.Handle(query);
        }
    }
}
