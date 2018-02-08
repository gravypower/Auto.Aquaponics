using System;
using System.Collections.Generic;
using Ponics.Aquaponics.Configuration;

namespace Ponics.HardCodedData.AquaponicSystems
{
    public class AddAquaponicsSystemConfiguration: IAddAquaponicsSystemConfiguration
    {
        public List<Guid> SystemWideOrganisms => new List<Guid>
        {
            //Nitrosomonas
            Guid.Parse("7227ab4569a145f6a8504a6181605b78"),
            //Nitrospira
            Guid.Parse("1c31691a2eba4733b331c77831e8d0f1")
        };
    }
}
