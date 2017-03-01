using System.Diagnostics;

namespace Auto.Aquaponics.Kernel.Tests.GraphTheory.Graphs
{
    [DebuggerDisplay("{_name}")]
    public class DummeyType
    {
        private readonly string _name;

        public DummeyType()
        {
            
        }

        public DummeyType(string name)
        {
            _name = name;
        }
    }
}
