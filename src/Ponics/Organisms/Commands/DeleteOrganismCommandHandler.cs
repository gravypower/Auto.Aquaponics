using System;
using System.Collections.Generic;
using Ponics.Aquaponics;
using Ponics.Aquaponics.Queries;
using Ponics.Kernel.Commands;
using Ponics.Kernel.Queries;

namespace Ponics.Organisms.Commands
{
    public class DeleteOrganismCommandHandler : ICommandHandler<DeleteOrganism>
    {
        private readonly IDataCommandHandler<DeleteOrganism> _deleteOrganismDataCommandHandler;
        private readonly IDataQueryHandler<GetAllAquaponicSystems, List<AquaponicSystem>> _getAllSystemsDataQueryHandler;

        public DeleteOrganismCommandHandler(
            IDataCommandHandler<DeleteOrganism> deleteOrganismDataCommandHandler,
            IDataQueryHandler<GetAllAquaponicSystems, List<AquaponicSystem>> getAllSystemsDataQueryHandler
            )
        {
            _deleteOrganismDataCommandHandler = deleteOrganismDataCommandHandler;
            _getAllSystemsDataQueryHandler = getAllSystemsDataQueryHandler;
        }

        public void Handle(DeleteOrganism command)
        {
            GuardOrganismInUse(command);
            _deleteOrganismDataCommandHandler.Handle(command);
        }

        private void GuardOrganismInUse(DeleteOrganism command)
        {
            var systems = _getAllSystemsDataQueryHandler.Handle(new GetAllAquaponicSystems());
            var organismsInUse = new List<Guid>();

            if (systems == null) return;

            foreach (var system in systems)
            {
                foreach (var component in system.Components)
                {
                    organismsInUse.AddRange(component.Organisms);
                }
            }

            if (organismsInUse.Contains(command.OrganismId))
            {
                throw new OrganismReferencedException();
            }
        }
    }
}
