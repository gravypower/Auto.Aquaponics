using System;
using Ponics.Kernel.Queries;
using ServiceStack;

namespace Ponics.Utils
{
    [Api("Gets a new Guid")]
    [Route("/utils/guid", "GET")]
    public class GetNewGuid: IQuery<NewGuid>
    {
    }

    public class NewGuid
    {
        public Guid Guid { get; set; }
    }
}
