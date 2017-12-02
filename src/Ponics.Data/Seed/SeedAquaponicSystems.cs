using System.Collections.Generic;
using Ponics.AquaponicSystems;
using Ponics.HardCodedData.Systems;

namespace Ponics.Data.Seed
{
    public class SeedAquaponicSystems:SeedData<AquaponicSystem>
    {
        public override IEnumerable<AquaponicSystem> GetSeedData()
        {
            yield return new AaronsAquaponicsSystem();
        }
    }
}