using System;
using Ponics.Authentication.Users;

namespace Ponics.HardCodedData.Users
{
    public class AaronJob
    {
        public static User SeedSystem()
        {
            return new User
            {
                Id = Guid.Parse("66b74b107786014485fca86e00a07bb4"),
                PonicsSystemIds = {Guid.Parse("66b74b107786014485fca86e00a07bb4") }
            };
        }
    }
}
