using System;
using System.Collections.Generic;
using Auto.Aquaponics.AquaponicSystems;
using Auto.Aquaponics.Components;
using Auto.Aquaponics.HardCodedData.Organisms;
using Auto.Aquaponics.Queries;

namespace Auto.Aquaponics.HardCodedData
{
    public class GetAllSystemsHandler: IQueryHandler<GetAllSystems, IList<AquaponicSystem>>
    {
        public IList<AquaponicSystem> Handle(GetAllSystems query)
        {
            var nitrosomonas = new Nitrosomonas();
            var nitrospira = new Nitrospira();

            var gravyNumberOne = new AquaponicSystem(Guid.Parse("47236a2e40f047a2923034c610c5e444"), "Aaron's Aquaponics System");

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
