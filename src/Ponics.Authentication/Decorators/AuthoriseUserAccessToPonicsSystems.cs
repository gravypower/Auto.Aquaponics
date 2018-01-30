﻿using System.Collections.Generic;
using Ponics.Authentication.User.Queries;
using Ponics.Kernel.Queries;
using Ponics.Queries;

namespace Ponics.Authentication.Decorators
{
    public class AuthoriseUserAccessToPonicsSystems<TGetAllPonicsSystem, TPonicsSystem> : IQueryHandler<TGetAllPonicsSystem, List<TPonicsSystem>>
        where TPonicsSystem : PonicsSystem
        where TGetAllPonicsSystem : GetAllPonicsSystems<TPonicsSystem>
    {
        private readonly IQueryHandler<TGetAllPonicsSystem, List<TPonicsSystem>> _decorated;

        public AuthoriseUserAccessToPonicsSystems(
            IQueryHandler<TGetAllPonicsSystem, List<TPonicsSystem>> decorated)
        {
            _decorated = decorated;
        }

        public List<TPonicsSystem> Handle(TGetAllPonicsSystem query)
        {
            return _decorated.Handle(query);
        }
    }
}
