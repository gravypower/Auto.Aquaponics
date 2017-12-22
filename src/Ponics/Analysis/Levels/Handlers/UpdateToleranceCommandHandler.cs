using System.Collections.Generic;
using System.Linq;
using Ponics.Analysis.Levels.Commands;
using Ponics.Analysis.Levels.MagicStrings;
using Ponics.Kernel.Data;
using Ponics.Organisms;

namespace Ponics.Analysis.Levels.Handlers
{
    public class UpdateToleranceCommandHandler<TTolerance> : ToleranceCommandHandler<TTolerance, UpdateTolerance<TTolerance>>
        where TTolerance : Tolerance
    {
        public UpdateToleranceCommandHandler(
            IDataQueryHandler<GetOrganisms, List<Organism>> getAllOrganismsDataQueryHandler, 
            IDataCommandHandler<UpdateOrganism> updateOrganismDataCommandHandler, 
            IToleranceMagicStrings toleranceMagicStrings) : 
            base(getAllOrganismsDataQueryHandler, updateOrganismDataCommandHandler, toleranceMagicStrings)
        {
        }

        public override void DoHandle(UpdateTolerance<TTolerance> command, Organism organism)
        {
            var tolerance = organism.Tolerances.SingleOrDefault(t => t.Type == command.Tolerance.Type);
            organism.Tolerances.Remove(tolerance);
            organism.Tolerances.Add(command.Tolerance);
        }
    }
}
