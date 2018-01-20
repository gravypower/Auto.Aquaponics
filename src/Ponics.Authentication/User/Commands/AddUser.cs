using System;
using Ponics.Kernel.Commands;
using ServiceStack;

namespace Ponics.Authentication.User
{
    [Api("Adds a user")]
    [Route("/user", "POST")]
    public class AddUser : ICommand, IDataCommand
    {
        [ApiMember(Name = "UserId", Description = "The of a user",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("UserId", typeof(Guid))]
        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
