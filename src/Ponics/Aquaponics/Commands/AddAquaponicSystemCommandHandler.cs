using Ponics.Kernel.Commands;

namespace Ponics.Aquaponics.Commands
{
    public class AddAquaponicSystemCommandHandler : ICommandHandler<AddAquaponicSystem>
    {
        private readonly IDataCommandHandler<AddAquaponicSystem> _addSystemDataCommandHandler;

        public AddAquaponicSystemCommandHandler(IDataCommandHandler<AddAquaponicSystem> addSystemDataCommandHandler)
        {
            _addSystemDataCommandHandler = addSystemDataCommandHandler;
        }

        public void Handle(AddAquaponicSystem command)
        {
            _addSystemDataCommandHandler.Handle(command);
        }
    }
}
