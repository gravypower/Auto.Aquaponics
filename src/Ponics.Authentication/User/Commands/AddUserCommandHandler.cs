using Ponics.Kernel.Commands;

namespace Ponics.Authentication.User.Commands
{
    public class AddUserCommandHandler:ICommandHandler<AddUser>
    {
        private readonly IDataCommandHandler<AddUser> _addUserDataCommandHandler;

        public AddUserCommandHandler(IDataCommandHandler<AddUser> addUserDataCommandHandler)
        {
            _addUserDataCommandHandler = addUserDataCommandHandler;
        }

        public void Handle(AddUser command)
        {
            _addUserDataCommandHandler.Handle(command);
        }
    }
}
