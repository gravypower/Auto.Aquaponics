using System;
using System.Collections.Generic;
using ServiceStack;

namespace Ponics.Authentication.User
{
    public class User
    {
        [ApiMember(ExcludeInSchema = true)]
        public Guid Id { get; set; }

        [ApiMember(ExcludeInSchema = true)]
        public List<Guid> PonicsSystemIds { get; set; }
    }
}
