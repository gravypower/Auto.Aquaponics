using Ponics.Aquaponics;
using Ponics.Aquaponics.Commands;
using Ponics.Aquaponics.Queries;
using Ponics.Components.Queries;
using Ponics.Kernel.Commands;
using Ponics.Kernel.Queries;

namespace Ponics.Components.Commands
{
    public class ConnectComponentsCommandHandler : ICommandHandler<ConnectComponents>
    {
        private readonly IDataCommandHandler<UpdateAquaponicSystem> _updateSystemDataCommandHandler;
        private readonly IDataQueryHandler<GetAquaponicSystem, AquaponicSystem> _getSystemDataCommandHandler;

        public ConnectComponentsCommandHandler(
            IDataCommandHandler<UpdateAquaponicSystem> updateSystemDataCommandHandler,
            IDataQueryHandler<GetAquaponicSystem, AquaponicSystem> getSystemDataCommandHandler)
        {
            _updateSystemDataCommandHandler = updateSystemDataCommandHandler;
            _getSystemDataCommandHandler = getSystemDataCommandHandler;
        }

        public void Handle(ConnectComponents command)
        {
            var system = _getSystemDataCommandHandler.Handle(new GetAquaponicSystem
            {
                SystemId = command.SystemId
            });

            system.ComponentConnections.Add(command.ComponentConnection);

            _updateSystemDataCommandHandler.Handle(new UpdateAquaponicSystem
            {
                System = system
            });
        }
    }
}
