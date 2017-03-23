using System.Collections.Generic;
using Auto.Aquaponics.AquaponicSystems;
using Auto.Aquaponics.Components;
using Auto.Aquaponics.Kernel.GraphTheory.Graphs;
using Auto.Aquaponics.Kernel.Query;

namespace Auto.Aquaponics.HardCodedData
{
    public class GetSystemsHandler:IQueryHandler<GetSystems, IList<AquaponicSystem>>
    {
        public IList<AquaponicSystem> Handle(GetSystems query)
        {
            var gravyNumberOne = new AquaponicSystem("Gravy Number One", new DirectedAcyclicGraph<Component>());
            var fishTank = new Component();
            var growBed = new Component();
            var sumpTank = new Component();
            gravyNumberOne.AddComponents(fishTank, growBed, sumpTank);

            return new List<AquaponicSystem>
            {
                gravyNumberOne
            };
        }
    }
}
