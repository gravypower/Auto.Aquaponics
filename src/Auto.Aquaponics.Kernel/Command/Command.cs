namespace Auto.Aquaponics.Kernel.Command
{
    public abstract class Command
    {
        public virtual string CommandVerb { get; } = string.Empty;

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(CommandVerb))
            {
                return CommandVerb;
            }

            return GetType().FullName;
        }
    }
}