using System;
using System.Collections.Generic;

namespace Ponics.Data.Users
{
    public class User
    {
        public Guid Id { get; set; }
        public List<Guid> PonicsSystemIds { get; set; }
    }
}
