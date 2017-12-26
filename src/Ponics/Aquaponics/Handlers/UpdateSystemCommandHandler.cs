using Ponics.Commands;
using Ponics.Kernel.Data;

namespace Ponics.Aquaponics.Handlers
{
    public class UpdateSystemCommandHandler : ICommandHandler<UpdateSystem>
    {
        private readonly IDataCommandHandler<UpdateSystem> _updateDataCommandHandler;

        public UpdateSystemCommandHandler(IDataCommandHandler<UpdateSystem> updateDataCommandHandler)
        {
            _updateDataCommandHandler = updateDataCommandHandler;
        }

        public void Handle(UpdateSystem command)
        {
            _updateDataCommandHandler.Handle(command);
        }
    }
}
