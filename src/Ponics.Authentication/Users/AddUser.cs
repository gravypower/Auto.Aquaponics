using System;
using Ponics.Kernel.Commands;

namespace Ponics.Authentication.Users
{
    public class AddUser : IDataCommand
    {
        public Guid UserId { get; set; }
    }
}
