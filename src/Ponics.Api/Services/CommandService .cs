using Ponics.Api.CompositionRoot;
using Ponics.Commands;
using ServiceStack;

namespace Ponics.Api.Services
{
    public abstract class CommandService : Service
    {
        public virtual void Exec<TCommand>(TCommand command) where TCommand : Commands.Command
        {
            var commandHandler = Bootstrapper.GetCommandHandler(command.GetType()) as ICommandHandler<TCommand>;

            commandHandler.Handle(command);
        }
    }
}
