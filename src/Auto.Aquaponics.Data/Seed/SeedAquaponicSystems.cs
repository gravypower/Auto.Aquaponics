using System.Collections.Generic;
using Auto.Aquaponics.AquaponicSystems;
using Auto.Aquaponics.HardCodedData.Systems;

namespace Auto.Aquaponics.Data.Seed
{
    public class SeedAquaponicSystems:SeedData<AquaponicSystem>
    {
        public override IEnumerable<AquaponicSystem> GetSeedData()
        {
            yield return new AaronsAquaponicsSystem();
        }
    }
}