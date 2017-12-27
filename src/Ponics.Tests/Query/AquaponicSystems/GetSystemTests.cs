using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Ponics.Aquaponics;
using Ponics.Aquaponics.Handlers;
using Ponics.Kernel.Data;

namespace Ponics.Tests.Query.AquaponicSystems
{
    [TestFixture]
    public class GetSystemTests
    {
        public GetSystemQueryHandler Sut;
        private IDataQueryHandler<GetSystem, AquaponicSystem> _getSystemDataQueryHandler;

        [SetUp]
        public void SetUp()
        {
            _getSystemDataQueryHandler = Substitute.For<IDataQueryHandler<GetSystem, AquaponicSystem>>();

            Sut = new GetSystemQueryHandler(_getSystemDataQueryHandler);
        }

        [Test]
        public void CanGetSystem()
        {
            //Assign
            var query  = new GetSystem();
            var system = new AquaponicSystem();
            _getSystemDataQueryHandler.Handle(Arg.Any<GetSystem>()).Returns(system);

            //Act
            var result = Sut.Handle(query);

            //Assert
            _getSystemDataQueryHandler.Received().Handle(Arg.Any<GetSystem>());
            result.Should().Be(system);
        }
    }
}
