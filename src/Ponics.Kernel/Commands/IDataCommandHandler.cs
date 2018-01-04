namespace Ponics.Kernel.Commands
{
    public interface IDataCommandHandler<in TCommand> where TCommand:IDataCommand
    {
        void Handle(TCommand command);
    }
}