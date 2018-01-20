using System;
using Ponics.Kernel.Queries;
using ServiceStack;

namespace Ponics.Authentication.User.Queries
{
    [Api("Gets a user")]
    [Route("/user", "GET")]
    public class GetUser : IQuery<User>, IDataQuery<User>
    {
        [ApiMember(Name = "UserId", Description = "The of a user",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("UserId", typeof(Guid))]
        public Guid UserId { get; set; }
    }
}
