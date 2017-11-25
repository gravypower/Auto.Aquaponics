namespace Auto.Aquaponics.Commands
{
    public interface ICommandHandler<in TCommand>
    {
        void Handle(TCommand command);
    }
}