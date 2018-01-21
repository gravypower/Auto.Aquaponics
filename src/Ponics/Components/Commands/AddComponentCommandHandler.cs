using System;
using Ponics.Aquaponics;
using Ponics.Aquaponics.Commands;
using Ponics.Aquaponics.Queries;
using Ponics.Kernel.Commands;
using Ponics.Kernel.Queries;

namespace Ponics.Components.Commands
{
    public class AddComponentCommandHandler : ICommandHandler<AddComponent>
    {
        private readonly IDataCommandHandler<UpdateSystem> _updateSystemDataCommandHandler;
        private readonly IDataQueryHandler<GetAquaponicSystem, AquaponicSystem> _getSystemDataCommandHandler;

        public AddComponentCommandHandler(
            IDataCommandHandler<UpdateSystem> updateSystemDataCommandHandler, 
            IDataQueryHandler<GetAquaponicSystem, AquaponicSystem> getSystemDataCommandHandler)
        {
            _updateSystemDataCommandHandler = updateSystemDataCommandHandler;
            _getSystemDataCommandHandler = getSystemDataCommandHandler;
        }

        public void Handle(AddComponent command)
        {
            var system = _getSystemDataCommandHandler.Handle( new GetAquaponicSystem
            {
                SystemId = command.SystemId
            });

            command.Component.Id = Guid.NewGuid();

            system.Components.Add(command.Component);

            _updateSystemDataCommandHandler.Handle(new UpdateSystem
            {
                System = system,
                SystemId = command.SystemId
            });
        }
    }
}
