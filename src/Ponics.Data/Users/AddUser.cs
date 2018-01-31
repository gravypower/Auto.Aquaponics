using System;
using Ponics.Kernel.Commands;

namespace Ponics.Data.Users
{
    public class AddUser : IDataCommand
    {
        public Guid UserId { get; set; }
    }
}
