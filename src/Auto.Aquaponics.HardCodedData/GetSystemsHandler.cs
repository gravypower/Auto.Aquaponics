using System.Collections.Generic;
using Auto.Aquaponics.AquaponicSystems;
using Auto.Aquaponics.Components;
using Auto.Aquaponics.HardCodedData.Organisms;
using Auto.Aquaponics.Kernel.Query;

namespace Auto.Aquaponics.HardCodedData
{
    public class GetSystemsHandler:IQueryHandler<GetSystems, IList<AquaponicSystem>>
    {
        public IList<AquaponicSystem> Handle(GetSystems query)
        {
            var nitrosomonas = new Nitrosomonas();
            var nitrospira = new Nitrospira();

            var gravyNumberOne = new AquaponicSystem("Gravy Number One");

            var fishTank = new Component("fishTank");
            fishTank.AddOrganisms(new SilverPerch(), nitrosomonas, nitrospira);

            var growBed = new Component("growBed");
            growBed.AddOrganisms(new Worm(), nitrosomonas, nitrospira);

            var sumpTank = new Component("sumpTank");
            sumpTank.AddOrganisms(new GoldFish(), nitrosomonas, nitrospira);

            gravyNumberOne.AddComponents(fishTank, growBed, sumpTank);

            return new List<AquaponicSystem>
            {
                gravyNumberOne
            };
        }
    }
}
