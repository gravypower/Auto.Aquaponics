namespace Auto.Aquaponics.Commands
{
    public interface ICommand
    {
    }

    public abstract class Command : ICommand
    {
        public virtual string CommandVerb { get; } = string.Empty;

        public override string ToString()
        {
            return !string.IsNullOrEmpty(CommandVerb) ? CommandVerb : GetType().FullName;
        }
    }
}