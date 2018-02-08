using System;
using System.Collections.Generic;

namespace Ponics.Aquaponics.Configuration
{
    public interface IAddAquaponicsSystemConfiguration
    {
        List<Guid> SystemWideOrganisms { get; }
    }
}
