using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Ponics.Aquaponics;
using Ponics.Aquaponics.Queries;
using Ponics.HardCodedData.AquaponicSystems;
using Ponics.Kernel.Queries;
using Ponics.Queries;

namespace Ponics.Tests.Query
{
    [TestFixture]
    public class GetSystemLevelsTests
    {
        private IDataQueryHandler<GetAquaponicSystem, AquaponicSystem> _getSystemDataQueryHandler;
        public GetSystemLevelsQueryHandler Sut;
        private AquaponicSystem _aquaponicSystem;
        private GetSystemLevels _getSystemLevels;

        [SetUp]
        public void SetUp()
        {
            _getSystemDataQueryHandler = Substitute.For<IDataQueryHandler<GetAquaponicSystem, AquaponicSystem>>();
            Sut = new GetSystemLevelsQueryHandler(_getSystemDataQueryHandler);
            _aquaponicSystem = AaronsAquaponicSystem.SeedSystem();
            _getSystemLevels = new GetSystemLevels { SystemId = _aquaponicSystem.Id };
            _getSystemDataQueryHandler.Handle(Arg.Any<GetAquaponicSystem>()).Returns(_aquaponicSystem);
        }

        [Test]
        public void CanGetSystem()
        {
            //Act
            Sut.Handle(_getSystemLevels);

            //Assert
            _getSystemDataQueryHandler.Received().Handle(Arg.Is<GetAquaponicSystem>( q =>q.SystemId == _aquaponicSystem.Id ));
        }

        [Test]
        public void CanGetpHLevels()
        {
            //Assign
            _getSystemLevels.Type = "pH";

            //Act
            var result = Sut.Handle(_getSystemLevels);

            //Assert
            result.Should().Contain(lr => lr.Type == "pH");
        }

        [Test]
        public void CanGetAmmoniaLevels()
        {
            //Assign
            _getSystemLevels.Type = "Ammonia";

            //Act
            var result = Sut.Handle(_getSystemLevels);

            //Assert
            result.Should().Contain(lr => lr.Type == "Ammonia");
            result.Should().NotContain(lr => lr.Type == "pH");
        }
    }
}
