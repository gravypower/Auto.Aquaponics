using System.Collections.Generic;
using System.Linq;
using Ponics.Analysis.Levels.Commands;
using Ponics.Analysis.Levels.MagicStrings;
using Ponics.Kernel.Data;
using Ponics.Organisms;

namespace Ponics.Analysis.Levels.Handlers
{
    public class DeleteToleranceCommandHandler<TTolerance> : ToleranceCommandHandler<TTolerance, DeleteTolerance<TTolerance>>
        where TTolerance : Tolerance
    {
        public DeleteToleranceCommandHandler(
            IDataQueryHandler<GetAllOrganisms, List<Organism>> getAllOrganismsDataQueryHandler, 
            IDataCommandHandler<UpdateOrganism> updateOrganismDataCommandHandler, 
            IToleranceMagicStrings toleranceMagicStrings) : 
            base(getAllOrganismsDataQueryHandler, updateOrganismDataCommandHandler, toleranceMagicStrings)
        {
        }

        public override void DoHandle(DeleteTolerance<TTolerance> command, Organism organism)
        {
            var tolerance = organism.Tolerances.SingleOrDefault(t => t.Type == command.Tolerance.Type);
            organism.Tolerances.Remove(tolerance);
        }
    }
}
