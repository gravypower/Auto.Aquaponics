using Ponics.Aquaponics;
using Ponics.Commands;
using Ponics.Kernel.Commands;
using Ponics.Kernel.Queries;

namespace Ponics.Components
{
    public class ConnectComponentsCommandHandler : ICommandHandler<ConnectComponents>
    {
        private readonly IDataCommandHandler<UpdateSystem> _updateSystemDataCommandHandler;
        private readonly IDataQueryHandler<GetSystem, AquaponicSystem> _getSystemDataCommandHandler;

        public ConnectComponentsCommandHandler(
            IDataCommandHandler<UpdateSystem> updateSystemDataCommandHandler,
            IDataQueryHandler<GetSystem, AquaponicSystem> getSystemDataCommandHandler)
        {
            _updateSystemDataCommandHandler = updateSystemDataCommandHandler;
            _getSystemDataCommandHandler = getSystemDataCommandHandler;
        }

        public void Handle(ConnectComponents command)
        {
            var system = _getSystemDataCommandHandler.Handle(new GetSystem
            {
                SystemId = command.SystemId
            });

            system.ComponentConnections.Add(command.ComponentConnection);

            _updateSystemDataCommandHandler.Handle(new UpdateSystem
            {
                System = system
            });
        }
    }
}
