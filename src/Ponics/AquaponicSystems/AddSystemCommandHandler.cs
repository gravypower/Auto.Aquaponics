using Ponics.Commands;
using Ponics.Kernel.Data;

namespace Ponics.AquaponicSystems
{
    public class AddSystemCommandHandler : ICommandHandler<AddSystem>
    {
        private readonly IDataCommandHandler<AddSystem> _addSystemDataCommandHandler;

        public AddSystemCommandHandler(
            IDataCommandHandler<AddSystem> updateSystemDataCommandHandler)
        {
            _addSystemDataCommandHandler = updateSystemDataCommandHandler;
        }


        public void Handle(AddSystem command)
        {
            _addSystemDataCommandHandler.Handle(command);
        }
    }
}
