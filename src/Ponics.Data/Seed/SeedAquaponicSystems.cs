
using System.Collections.Generic;
using Ponics.Aquaponics;
using Ponics.HardCodedData.AquaponicSystems;

namespace Ponics.Data.Seed
{
    public class SeedAquaponicSystems : SeedData<AquaponicSystem>
    {
        public override IEnumerable<AquaponicSystem> GetSeedData()
        {
            yield return AaronsAquaponicSystem.SeedSystem();
        }
    }
}
