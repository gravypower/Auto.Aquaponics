using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Ponics.Analysis.PonicsSystemLevels;
using Ponics.Aquaponics;
using Ponics.HardCodedData.AquaponicSystems;
using Ponics.Kernel.Queries;
using Ponics.Organisms;
using Ponics.Strategies;

namespace Ponics.Tests.Query.PonicsSystemLevels
{
    public class AnalysePonicsSystemLevelsTests
    {
        public AnalysePonicsSystemLevelsHandler Sut;
        private IQueryStrategyHandler<GetPonicSystemOrganisms, List<Organism>> _getPonicSystemOrganismsHandler;
        private IDataQueryHandler<GetSystem, AquaponicSystem> _getSystemDataQueryHandler;


        [SetUp]
        public void SetUp()
        {
            _getSystemDataQueryHandler = Substitute.For<IDataQueryHandler<GetSystem, AquaponicSystem>>();
            _getPonicSystemOrganismsHandler = Substitute.For<IQueryStrategyHandler<GetPonicSystemOrganisms, List<Organism>>>();

            Sut = new AnalysePonicsSystemLevelsHandler(_getPonicSystemOrganismsHandler, _getSystemDataQueryHandler);
        }

        [Test]
        public void Play()
        {
            _getSystemDataQueryHandler.Handle(Arg.Any<GetSystem>()).Returns(AaronsAquaponicSystem.SeedSystem());
            Sut.Handle(new AnalysePonicsSystemLevels());
        }
    }
}
