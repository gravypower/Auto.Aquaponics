using Ponics.Components;

namespace Ponics.AquaponicSystems
{
    public class ComponentConnection
    {
        public string SourceId { get; }
        public string TargetId { get; }

        public ComponentConnection(Component source, Component target)
        {
            TargetId = target.Name;
            SourceId = source.Name;
        }
    }
}