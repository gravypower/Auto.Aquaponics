using Ponics.Kernel.Commands;

namespace Ponics.Aquaponics.Commands
{
    public class UpdateSystemCommandHandler : ICommandHandler<UpdateAquaponicSystem>
    {
        private readonly IDataCommandHandler<UpdateAquaponicSystem> _updateDataCommandHandler;

        public UpdateSystemCommandHandler(IDataCommandHandler<UpdateAquaponicSystem> updateDataCommandHandler)
        {
            _updateDataCommandHandler = updateDataCommandHandler;
        }

        public void Handle(UpdateAquaponicSystem command)
        {
            _updateDataCommandHandler.Handle(command);
        }
    }
}
