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
        private IDataQueryHandler<GetAllSystems, List<AquaponicSystem>> _getAllSystemsDataQueryHandler;

        [SetUp]
        public void SetUp()
        {
            _getAllSystemsDataQueryHandler = Substitute.For<IDataQueryHandler<GetAllSystems, List<AquaponicSystem>>>();

            Sut = new GetSystemQueryHandler(_getAllSystemsDataQueryHandler);
        }

        [Test]
        public void CanGetSystem()
        {
            //Assign
            var query  = new GetSystem();
            var system = new AquaponicSystem();
            _getAllSystemsDataQueryHandler.Handle(Arg.Any<GetAllSystems>()).Returns(
                new List<AquaponicSystem>
                {
                 system   
                });

            //Act
            var result = Sut.Handle(query);

            //Assert
            _getAllSystemsDataQueryHandler.Received().Handle(Arg.Any<GetAllSystems>());
            result.Should().Be(system);
        }
    }
}
