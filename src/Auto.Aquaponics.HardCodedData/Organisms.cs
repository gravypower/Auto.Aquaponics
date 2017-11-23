using Auto.Aquaponics.HardCodedData.Organisms;
using Auto.Aquaponics.Organisms;
using System.Collections.Generic;

namespace Auto.Aquaponics.HardCodedData
{
    public class OrganismList: List<Organism>
    {
        public OrganismList()
        {
            Add(new GoldFish());
            Add(new Nitrosomonas());
            Add(new Nitrospira());
            Add(new SilverPerch());
            Add(new Worm());
        }
    }
}
