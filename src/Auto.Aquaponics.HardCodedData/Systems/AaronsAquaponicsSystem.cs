using System;
using Auto.Aquaponics.AquaponicSystems;
using Auto.Aquaponics.Components;
using Auto.Aquaponics.HardCodedData.Organisms;

namespace Auto.Aquaponics.HardCodedData.Systems
{
    public class AaronsAquaponicsSystem: AquaponicSystem
    {
        public AaronsAquaponicsSystem()
        {
            Id = Guid.Parse("47236a2e40f047a2923034c610c5e444");
            Name = "Aaron's Aquaponics System";
            
            var nitrosomonas = new Nitrosomonas();
            var nitrospira = new Nitrospira();

            var fishTank = new Component {Name = "fishTank"};
            
            fishTank.AddOrganisms(new SilverPerch().Id, nitrosomonas.Id, nitrospira.Id);

            var growBed = new Component {Name = "growBed"};
            growBed.AddOrganisms(new Worm().Id, nitrosomonas.Id, nitrospira.Id);

            var sumpTank = new Component {Name = "sumpTank"};
            sumpTank.AddOrganisms(new GoldFish().Id, nitrosomonas.Id, nitrospira.Id);

            AddComponents(fishTank, growBed, sumpTank);
        }
    }
}
