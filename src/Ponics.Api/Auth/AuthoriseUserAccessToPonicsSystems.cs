using System.Collections.Generic;
using Ponics.Kernel.Queries;
using Ponics.Queries;

namespace Ponics.Api.Auth
{
    public class AuthoriseUserAccessToPonicsSystems<TGetAllPonicsSystem, TPonicsSystem> : IQueryHandler<TGetAllPonicsSystem, List<TPonicsSystem>>
        where TPonicsSystem : PonicsSystem
        where TGetAllPonicsSystem : GetAllPonicsSystems<TPonicsSystem>
    {
        private readonly IQueryHandler<TGetAllPonicsSystem, List<TPonicsSystem>> _decorated;
        private readonly Context _context;

        public AuthoriseUserAccessToPonicsSystems(
            IQueryHandler<TGetAllPonicsSystem, List<TPonicsSystem>> decorated, Context context)
        {
            _decorated = decorated;
            _context = context;
        }

        public List<TPonicsSystem> Handle(TGetAllPonicsSystem query)
        {
            var t = _context.UserId;
            return _decorated.Handle(query);
        }
    }
}
