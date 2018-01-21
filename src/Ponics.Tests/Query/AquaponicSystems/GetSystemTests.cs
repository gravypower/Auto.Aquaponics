using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Ponics.Aquaponics;
using Ponics.Aquaponics.Queries;
using Ponics.Kernel.Queries;

namespace Ponics.Tests.Query.AquaponicSystems
{
    [TestFixture]
    public class GetSystemTests
    {
        public GetAquaponicSystemQueryHandler Sut;
        private IDataQueryHandler<GetAquaponicSystem, AquaponicSystem> _getSystemDataQueryHandler;

        [SetUp]
        public void SetUp()
        {
            _getSystemDataQueryHandler = Substitute.For<IDataQueryHandler<GetAquaponicSystem, AquaponicSystem>>();

            Sut = new GetAquaponicSystemQueryHandler(_getSystemDataQueryHandler);
        }

        [Test]
        public void CanGetSystem()
        {
            //Assign
            var query  = new GetAquaponicSystem();
            var system = new AquaponicSystem();
            _getSystemDataQueryHandler.Handle(Arg.Any<GetAquaponicSystem>()).Returns(system);

            //Act
            var result = Sut.Handle(query);

            //Assert
            _getSystemDataQueryHandler.Received().Handle(Arg.Any<GetAquaponicSystem>());
            result.Should().Be(system);
        }
    }
}
