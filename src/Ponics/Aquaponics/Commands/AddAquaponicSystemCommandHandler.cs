using Ponics.Aquaponics.Configuration;
using Ponics.Kernel.Commands;

namespace Ponics.Aquaponics.Commands
{
    public class AddAquaponicSystemCommandHandler : ICommandHandler<AddAquaponicSystem>
    {
        private readonly IDataCommandHandler<AddAquaponicSystem> _addSystemDataCommandHandler;
        private readonly IAddAquaponicsSystemConfiguration _addAquaponicsSystemConfiguration;

        public AddAquaponicSystemCommandHandler(
            IDataCommandHandler<AddAquaponicSystem> addSystemDataCommandHandler,
            IAddAquaponicsSystemConfiguration addAquaponicsSystemConfiguration)
        {
            _addSystemDataCommandHandler = addSystemDataCommandHandler;
            _addAquaponicsSystemConfiguration = addAquaponicsSystemConfiguration;
        }

        public void Handle(AddAquaponicSystem command)
        {
            command.System.SystemWideOrganisms = _addAquaponicsSystemConfiguration.SystemWideOrganisms;
            _addSystemDataCommandHandler.Handle(command);
        }
    }
}
