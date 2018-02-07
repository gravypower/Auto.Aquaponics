using System.Linq;
using Ponics.Aquaponics;
using Ponics.Aquaponics.Commands;
using Ponics.Aquaponics.Queries;
using Ponics.Kernel.Commands;
using Ponics.Kernel.Queries;

namespace Ponics.Components.Commands
{
    public class DeleteComponentCommandHandler:ICommandHandler<DeleteComponent>
    {
        private readonly IDataCommandHandler<UpdateAquaponicSystem> _updateSystemDataCommandHandler;
        private readonly IDataQueryHandler<GetAquaponicSystem, AquaponicSystem> _getSystemDataCommandHandler;

        public DeleteComponentCommandHandler(
            IDataCommandHandler<UpdateAquaponicSystem> updateSystemDataCommandHandler,
            IDataQueryHandler<GetAquaponicSystem, AquaponicSystem> getSystemDataCommandHandler)
        {
            _updateSystemDataCommandHandler = updateSystemDataCommandHandler;
            _getSystemDataCommandHandler = getSystemDataCommandHandler;
        }

        public void Handle(DeleteComponent command)
        {
            var system = _getSystemDataCommandHandler.Handle(new GetAquaponicSystem
            {
                SystemId = command.SystemId
            });

            var component = system.Components.First(c => c.Id == command.ComponentId);
            system.Components.Remove(component);

            _updateSystemDataCommandHandler.Handle(new UpdateAquaponicSystem
            {
                System = system,
                SystemId = command.SystemId
            });
        }
    }
}
