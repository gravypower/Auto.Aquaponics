using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Ponics.Analysis.PonicsSystemLevels;
using Ponics.Kernel.Queries;
using Ponics.Organisms;
using Ponics.Strategies;
using Ponics.Strategies.Handlers;

namespace Ponics.Tests.Query.PonicsSystemLevels
{
    public class AnalysePonicsSystemLevelsTests
    {
        public AnalysePonicsSystemLevelsHandler Sut;
        private IQueryStrategyHandler<GetPonicSystemOrganisms, List<Organism>> _getPonicSystemOrganismsHandler;

        [SetUp]
        public void SetUp()
        {
            _getPonicSystemOrganismsHandler = Substitute.For<IQueryStrategyHandler<GetPonicSystemOrganisms, List<Organism>>>();
            Sut = new AnalysePonicsSystemLevelsHandler(_getPonicSystemOrganismsHandler);
        }
    }
}
