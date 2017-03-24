using Auto.Aquaponics.Components;

namespace Auto.Aquaponics.AquaponicSystems
{
    public class ComponentConnection
    {
        public string SourceId { get; }
        public string TargetId { get; }

        public ComponentConnection(Component source, Component target)
        {
            TargetId = target.Id;
            SourceId = source.Id;
        }
    }
}