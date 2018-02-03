using System;
using System.Collections.Generic;

namespace Ponics.Authentication.Users
{
    public class User
    {
        public Guid Id { get; set; }
        public List<Guid> PonicsSystemIds { get; set; }

        public User()
        {
            PonicsSystemIds = new List<Guid>();
        }
    }
}
