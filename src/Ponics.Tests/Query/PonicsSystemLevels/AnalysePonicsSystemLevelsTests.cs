using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Ponics.Analysis.Levels.Handlers;
using Ponics.Analysis.PonicsSystem;
using Ponics.Aquaponics;
using Ponics.Aquaponics.Queries;
using Ponics.HardCodedData.AquaponicSystems;
using Ponics.Kernel.Queries;
using Ponics.Organisms;
using Ponics.Strategies;
using Ponics.Strategies.Queries;

namespace Ponics.Tests.Query.PonicsSystemLevels
{
    public class AnalysePonicsSystemLevelsTests
    {
        public AnalysePonicsSystemHandler Sut;
        private IQueryStrategyHandler<GetPonicSystemOrganisms, List<Organism>> _getPonicSystemOrganismsHandler;
        private IDataQueryHandler<GetSystem, AquaponicSystem> _getSystemDataQueryHandler;
        private List<IAnalyseLevelsQueryHandler> _analyseLevelsQueryHandlers;


        [SetUp]
        public void SetUp()
        {
            _getSystemDataQueryHandler = Substitute.For<IDataQueryHandler<GetSystem, AquaponicSystem>>();
            _getPonicSystemOrganismsHandler = Substitute.For<IQueryStrategyHandler<GetPonicSystemOrganisms, List<Organism>>>();
            _analyseLevelsQueryHandlers = new List<IAnalyseLevelsQueryHandler>();

            Sut = new AnalysePonicsSystemHandler(
                _getPonicSystemOrganismsHandler, 
                _getSystemDataQueryHandler,
                _analyseLevelsQueryHandlers,
                null);
        }
    }
}
