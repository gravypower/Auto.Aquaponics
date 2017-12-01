using System;
using System.Collections.Generic;
using System.Linq;
using Auto.Aquaponics.Commands;
using Auto.Aquaponics.Kernel.Data;
using Auto.Aquaponics.Organisms;

namespace Auto.Aquaponics.Analysis.Levels
{
    public class AddToleranceCommandHandler<TTolerance> : ICommandHandler<AddTolerance<TTolerance>> 
        where TTolerance : Tolerance
    {
        private readonly IDataQueryHandler<GetAllOrganisms, IList<Organism>> _getAllOrganismsDataQueryHandler;
        private readonly IDataCommandHandler<UpdateOrganism> _updateOrganismDataCommandHandler;
        private readonly IToleranceMagicStrings _toleranceMagicStrings;

        public AddToleranceCommandHandler(
            IDataQueryHandler<GetAllOrganisms, IList<Organism>> getAllOrganismsDataQueryHandler,
            IDataCommandHandler<UpdateOrganism> updateOrganismDataCommandHandler,
            IToleranceMagicStrings toleranceMagicStrings)
        {
            _getAllOrganismsDataQueryHandler = getAllOrganismsDataQueryHandler;
            _updateOrganismDataCommandHandler = updateOrganismDataCommandHandler;
            _toleranceMagicStrings = toleranceMagicStrings;
        }

        public void Handle(AddTolerance<TTolerance> command)
        {
            var organisms = _getAllOrganismsDataQueryHandler.Handle(new GetAllOrganisms());
            var organism = organisms.Single(o => o.Id == command.OrganismId);

            if (organism.Tolerances.All(o => o.Type != command.Tolerance.Type))
            {
                organism.Tolerances.Add(command.Tolerance);
            }
            else
            {
                throw new InvalidOperationException(_toleranceMagicStrings.ToleranceAlreadyDefinedForOrganism);
            }

            _updateOrganismDataCommandHandler.Handle(new UpdateOrganism
            {
                Id = organism.Id,
                Organism = organism
            });
        }
    }
}

