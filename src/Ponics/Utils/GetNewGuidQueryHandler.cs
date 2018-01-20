using System;
using Ponics.Kernel.Queries;

namespace Ponics.Utils
{
    public class GetNewGuidQueryHandler:IQueryHandler<GetNewGuid, NewGuid>
    {
        public NewGuid Handle(GetNewGuid query)
        {
            return new NewGuid
            {
                Guid = Guid.NewGuid()
            };
        }
    }
}
