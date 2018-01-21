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
        private readonly IDataQueryHandler<GetAquaponicSystem, AquaponicSystem> _getSystemDataCommandHandler;

        public UpdateComponentCommandHandler(
            IDataCommandHandler<UpdateSystem> updateSystemDataCommandHandler,
            IDataQueryHandler<GetAquaponicSystem, AquaponicSystem> getSystemDataCommandHandler)
        {
            _updateSystemDataCommandHandler = updateSystemDataCommandHandler;
            _getSystemDataCommandHandler = getSystemDataCommandHandler;
        }


        public void Handle(UpdateComponent command)
        {
            var system = _getSystemDataCommandHandler.Handle(new GetAquaponicSystem
            {
                SystemId = command.SystemId
            });

            var oldComponentIndex = system.Components.FindIndex(c => c.Id == command.ComponentId);

            system.Components[oldComponentIndex] = command.Component;

            _updateSystemDataCommandHandler.Handle(new UpdateSystem
            {
                System = system,
                SystemId = command.SystemId
            });
        }
    }
}
