using Ponics.Api.CompositionRoot;
using Ponics.Commands;
using ServiceStack;
using Command = Ponics.Commands.Command;

namespace Ponics.Api
{
    public abstract class CommandService : Service
    {
        public virtual void Exec<TCommand>(TCommand command) where TCommand : Commands.Command
        {
            var commandHandler = Bootstrapper.GetCommandHandler(command.GetType()) as ICommandHandler<TCommand>;

            var body = this.Request.GetRawBody();

            commandHandler.Handle(command);
        }
    }
}
