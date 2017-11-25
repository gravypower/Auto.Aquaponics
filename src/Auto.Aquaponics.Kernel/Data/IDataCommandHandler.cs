namespace Auto.Aquaponics.Kernel.Data
{
    public interface IDataCommandHandler<in TCommand> where TCommand:IDataCommand
    {
        void Handle(TCommand command);
    }
}