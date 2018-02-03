using System;
using Ponics.Kernel.Queries;

namespace Ponics.Authentication.Users
{
    public class GetUser : IDataQuery<User>
    {
        public Guid UserId { get; set; }
    }
}
