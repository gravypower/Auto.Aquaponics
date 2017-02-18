namespace Auto.Aquaponics.Kernel.Command
{
    public interface ICommandHandler<in TCommand>
    {
        void Handle(TCommand command);
    }
}