using Ponics.Commands;
using Ponics.Kernel.Data;

namespace Ponics.Aquaponics.Handlers
{
    public class AddSystemCommandHandler : ICommandHandler<AddSystem>
    {
        private readonly IDataCommandHandler<AddSystem> _addSystemDataCommandHandler;

        public AddSystemCommandHandler(IDataCommandHandler<AddSystem> addSystemDataCommandHandler)
        {
            _addSystemDataCommandHandler = addSystemDataCommandHandler;
        }


        public void Handle(AddSystem command)
        {
            _addSystemDataCommandHandler.Handle(command);
        }
    }
}
