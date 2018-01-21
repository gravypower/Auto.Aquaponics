using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Ponics.Aquaponics;
using Ponics.Aquaponics.Queries;
using Ponics.Kernel.Queries;

namespace Ponics.Tests.Query.AquaponicSystems
{
    [TestFixture]
    public class GetAllSystemsTests
    {
        public GetAllAquaponicSystemsQueryHandler Sut;
        private IDataQueryHandler<GetAllAquaponicSystems, List<AquaponicSystem>> _getAllSystemsDataQueryHandler;

        [SetUp]
        public void SetUp()
        {
            _getAllSystemsDataQueryHandler = Substitute.For<IDataQueryHandler<GetAllAquaponicSystems, List<AquaponicSystem>>>();
            Sut = new GetAllAquaponicSystemsQueryHandler(_getAllSystemsDataQueryHandler);
        }

        [Test]
        public void CanGetAllSystems()
        {
            //Assign
            var query = new GetAllAquaponicSystems();
            var systemOne = new AquaponicSystem();
            var systemTwo = new AquaponicSystem();
            _getAllSystemsDataQueryHandler.Handle(Arg.Any<GetAllAquaponicSystems>()).Returns(
                new List<AquaponicSystem>
                {
                    systemOne,
                    systemTwo
                });

            //Act
            var result = Sut.Handle(query);

            //Assert
            _getAllSystemsDataQueryHandler.Received().Handle(query);
            result.Should().Contain(systemOne);
            result.Should().Contain(systemTwo);
        }
    }
}
