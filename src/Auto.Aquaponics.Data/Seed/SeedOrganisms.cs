using System.Collections.Generic;
using Auto.Aquaponics.HardCodedData.Organisms;
using Auto.Aquaponics.Organisms;

namespace Auto.Aquaponics.Data.Seed
{
    public class SeedOrganisms : SeedData<Organism>
    {
        public override IEnumerable<Organism> GetSeedData()
        {
            yield return new SilverPerch();
            yield return new GoldFish();
            yield return new Nitrosomonas();
            yield return new Nitrospira();
            yield return new Worm();
        }
    }
}
