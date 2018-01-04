using System;
using System.Collections.Generic;
using Ponics.Kernel.Queries;
using Ponics.Organisms;

namespace Ponics.Strategies
{
    public class GetPonicSystemOrganisms: IQueryStrategy<List<Organism>>
    {
        public Guid SystemId { get; set; }
    }
}
