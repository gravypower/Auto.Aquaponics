using System;
using Ponics.Commands;
using Ponics.Kernel.Data;

namespace Ponics.Organisms.Handlers
{
    public class AddOrganismCommandHandler: ICommandHandler<AddOrganism>
    {
        private readonly IDataCommandHandler<AddOrganism> _addOrganismDataCommandHandler;

        public AddOrganismCommandHandler(IDataCommandHandler<AddOrganism> addOrganismDataCommandHandler)
        {
            _addOrganismDataCommandHandler = addOrganismDataCommandHandler;
        }

        public void Handle(AddOrganism command)
        {
            command.Organism.Id = Guid.NewGuid();
            _addOrganismDataCommandHandler.Handle(command);
        }
    }
}
