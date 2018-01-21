using System.Threading;
using Ponics.Api.CompositionRoot;
using Ponics.Commands;
using Ponics.Kernel.Commands;
using ServiceStack;

namespace Ponics.Api.Services
{
    [Authenticate]
    public abstract class CommandService : Service
    {
        public virtual void Exec<TCommand>(TCommand command) where TCommand : ICommand
        {
#if DEBUG
            Thread.Sleep(3000);
#endif

            var commandHandler = Bootstrapper.GetCommandHandler(command.GetType()) as ICommandHandler<TCommand>;

            commandHandler.Handle(command);
        }
    }
}
