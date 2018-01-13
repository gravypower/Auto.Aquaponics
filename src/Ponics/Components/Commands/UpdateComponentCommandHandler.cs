using System.Linq;
using Ponics.Aquaponics;
using Ponics.Aquaponics.Commands;
using Ponics.Aquaponics.Queries;
using Ponics.Kernel.Commands;
using Ponics.Kernel.Queries;

namespace Ponics.Components.Commands
{
    public class UpdateComponentCommandHandler:ICommandHandler<UpdateComponent>
    {
        private readonly IDataCommandHandler<UpdateSystem> _updateSystemDataCommandHandler;
        private readonly IDataQueryHandler<GetSystem, AquaponicSystem> _getSystemDataCommandHandler;

        public UpdateComponentCommandHandler(
            IDataCommandHandler<UpdateSystem> updateSystemDataCommandHandler,
            IDataQueryHandler<GetSystem, AquaponicSystem> getSystemDataCommandHandler)
        {
            _updateSystemDataCommandHandler = updateSystemDataCommandHandler;
            _getSystemDataCommandHandler = getSystemDataCommandHandler;
        }


        public void Handle(UpdateComponent command)
        {
            var system = _getSystemDataCommandHandler.Handle(new GetSystem
            {
                SystemId = command.SystemId
            });

            var oldComponent = system.Components.First(c => c.Id == command.ComponentId);

            system.Components.Remove(oldComponent);
            system.Components.Add(command.Component);

            _updateSystemDataCommandHandler.Handle(new UpdateSystem
            {
                System = system,
                SystemId = command.SystemId
            });
        }
    }
}
