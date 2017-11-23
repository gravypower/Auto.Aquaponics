using System.Collections.Generic;
using Auto.Aquaponics.AquaponicSystems;
using Auto.Aquaponics.Components;
using Auto.Aquaponics.HardCodedData.Organisms;
using Auto.Aquaponics.Query;

namespace Auto.Aquaponics.HardCodedData
{
    public class GetAllSystemsHandler: IQueryHandler<GetAllSystems, IList<AquaponicSystem>>
    {
        public IList<AquaponicSystem> Handle(GetAllSystems query)
        {
            var nitrosomonas = new Nitrosomonas();
            var nitrospira = new Nitrospira();

            var gravyNumberOne = new AquaponicSystem("Gravypower_1");

            var fishTank = new Component("fishTank");
            fishTank.AddOrganisms(new SilverPerch().Id, nitrosomonas.Id, nitrospira.Id);

            var growBed = new Component("growBed");
            growBed.AddOrganisms(new Worm().Id, nitrosomonas.Id, nitrospira.Id);

            var sumpTank = new Component("sumpTank");
            sumpTank.AddOrganisms(new GoldFish().Id, nitrosomonas.Id, nitrospira.Id);

            gravyNumberOne.AddComponents(fishTank, growBed, sumpTank);

            return new List<AquaponicSystem>
            {
                gravyNumberOne
            };
        }
    }
}
