using Auto.Aquaponics.Commands;

using ServiceStack;
using Command = Auto.Aquaponics.Commands.Command;

namespace Auto.Aquaponics.Api
{
    public abstract class CommandService : Service
    {
        public virtual void Exec<TCommand>(TCommand command) where TCommand : Command
        {
            var commandHandler = Bootstrapper.GetCommandHandler(command.GetType()) as ICommandHandler<TCommand>;

            var body = this.Request.GetRawBody();

            commandHandler.Handle(command);
        }
    }
}
