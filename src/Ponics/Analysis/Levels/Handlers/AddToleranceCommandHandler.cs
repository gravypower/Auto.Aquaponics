using System;
using System.Collections.Generic;
using System.Linq;
using Ponics.Analysis.Levels.Commands;
using Ponics.Analysis.Levels.MagicStrings;
using Ponics.Kernel.Data;
using Ponics.Organisms;

namespace Ponics.Analysis.Levels.Handlers
{
    public class AddToleranceCommandHandler<TTolerance> : ToleranceCommandHandler<TTolerance, AddTolerance<TTolerance>> 
        where TTolerance : Tolerance
    {
        public AddToleranceCommandHandler(
            IDataQueryHandler<GetAllOrganisms, List<Organism>> getAllOrganismsDataQueryHandler, 
            IDataCommandHandler<UpdateOrganism> updateOrganismDataCommandHandler, 
            IToleranceMagicStrings toleranceMagicStrings) : 
            base(getAllOrganismsDataQueryHandler, updateOrganismDataCommandHandler, toleranceMagicStrings)
        {
        }

        public override void DoHandle(AddTolerance<TTolerance> command, Organism organism)
        {

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

