using Ponics.Kernel.Commands;

namespace Ponics.Aquaponics.Commands
{
    public class DeleteSystemCommandHandler : ICommandHandler<DeleteSystem>
    {
        private readonly IDataCommandHandler<DeleteSystem> _deleteSystemDataCommandHandler;

        public DeleteSystemCommandHandler(IDataCommandHandler<DeleteSystem> deleteSystemDataCommandHandler)
        {
            _deleteSystemDataCommandHandler = deleteSystemDataCommandHandler;
        }

        public void Handle(DeleteSystem command)
        {
            _deleteSystemDataCommandHandler.Handle(command);
        }
    }
}
