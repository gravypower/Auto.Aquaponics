using System.Collections.Generic;
using System.Linq;
using Ponics.Analysis.Levels;
using Ponics.Aquaponics;
using Ponics.Kernel.Data;
using Ponics.Kernel.Queries;
using Ponics.Queries;

namespace Ponics.Handlers
{
    public class GetSystemLevelsQueryHandler: IQueryHandler<GetSystemLevels, List<LevelReading>>
    {
        private readonly IDataQueryHandler<GetSystem, AquaponicSystem> _getSystemDataQueryHandler;

        public GetSystemLevelsQueryHandler(IDataQueryHandler<GetSystem, AquaponicSystem> getSystemDataQueryHandler)
        {
            _getSystemDataQueryHandler = getSystemDataQueryHandler;
        }

        public List<LevelReading> Handle(GetSystemLevels query)
        {
            var system = _getSystemDataQueryHandler.Handle(new GetSystem{SystemId = query.SystemId});

            return system.LevelReadings
                .Where(l=>l.Type == query.Type)
                .OrderBy(lr => lr.DateTime.ToDateTimeUtc())
                .ToList();
        }
    }
}