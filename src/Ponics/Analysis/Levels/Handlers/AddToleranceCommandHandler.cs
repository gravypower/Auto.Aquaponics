using System;
using System.Collections.Generic;
using System.Linq;
using Ponics.Analysis.Levels.Commands;
using Ponics.Analysis.Levels.MagicStrings;
using Ponics.Kernel.Commands;
using Ponics.Kernel.Queries;
using Ponics.Organisms;

namespace Ponics.Analysis.Levels.Handlers
{
    public class AddToleranceCommandHandler<TTolerance> : ToleranceCommandHandler<TTolerance, AddTolerance<TTolerance>> 
        where TTolerance : Tolerance
    {
        public AddToleranceCommandHandler(
            IDataQueryHandler<GetOrganisms, List<Organism>> getAllOrganismsDataQueryHandler, 
            IDataCommandHandler<UpdateOrganism> updateOrganismDataCommandHandler, 
            IToleranceMagicStrings toleranceMagicStrings) : 
            base(getAllOrganismsDataQueryHandler, updateOrganismDataCommandHandler, toleranceMagicStrings)
        {
        }

        public override void DoHandle(AddTolerance<TTolerance> command, Organism organism)
        {
            if (command.Tolerance == null)
            {
                throw new InvalidOperationException(ToleranceMagicStrings.ToleranceUndefined);
            }
            if (organism.Tolerances.All(o => o.Type != command.Tolerance.Type))
            {
                organism.Tolerances.Add(command.Tolerance);
            }
            else
            {
                throw new InvalidOperationException(ToleranceMagicStrings.ToleranceAlreadyDefinedForOrganism);
            }
        }
    }
}

