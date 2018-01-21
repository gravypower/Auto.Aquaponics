using System.Collections.Generic;
using System.Linq;
using Ponics.Analysis.Levels;
using Ponics.Aquaponics;
using Ponics.Aquaponics.Queries;
using Ponics.Kernel.Queries;

namespace Ponics.Queries
{
    public class GetSystemLevelsQueryHandler: IQueryHandler<GetSystemLevels, List<LevelReading>>
    {
        private readonly IDataQueryHandler<GetAquaponicSystem, AquaponicSystem> _getSystemDataQueryHandler;

        public GetSystemLevelsQueryHandler(IDataQueryHandler<GetAquaponicSystem, AquaponicSystem> getSystemDataQueryHandler)
        {
            _getSystemDataQueryHandler = getSystemDataQueryHandler;
        }

        public List<LevelReading> Handle(GetSystemLevels query)
        {
            var system = _getSystemDataQueryHandler.Handle(new GetAquaponicSystem{SystemId = query.SystemId});

            return system.LevelReadings
                .Where(l=>l.Type == query.Type)
                .OrderBy(lr => lr.DateTime.ToDateTimeUtc())
                .ToList();
        }
    }
}