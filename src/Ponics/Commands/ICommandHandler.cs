namespace Ponics.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand:Command
    {
        void Handle(TCommand command);
    }
}