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
        public GetAllSystemsQueryHandler Sut;
        private IDataQueryHandler<GetAllSystems, List<AquaponicSystem>> _getAllSystemsDataQueryHandler;

        [SetUp]
        public void SetUp()
        {
            _getAllSystemsDataQueryHandler = Substitute.For<IDataQueryHandler<GetAllSystems, List<AquaponicSystem>>>();
            Sut = new GetAllSystemsQueryHandler(_getAllSystemsDataQueryHandler);
        }

        [Test]
        public void CanGetAllSystems()
        {
            //Assign
            var query = new GetAllSystems();
            var systemOne = new AquaponicSystem();
            var systemTwo = new AquaponicSystem();
            _getAllSystemsDataQueryHandler.Handle(Arg.Any<GetAllSystems>()).Returns(
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
