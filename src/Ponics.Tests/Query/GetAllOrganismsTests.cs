
using System;
using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Ponics.Kernel.Queries;
using Ponics.Organisms;
using Ponics.Organisms.Queries;

namespace Ponics.Tests.Query
{
    [TestFixture]
    public class GetAllOrganismsTests
    {
        public GetOrganismsQueryHandler Sut;
        private IDataQueryHandler<GetOrganisms, List<Organism>> _getAllOrganismsDataQueryHandler;

        [SetUp]
        public void SetUp()
        {
            _getAllOrganismsDataQueryHandler = Substitute.For<IDataQueryHandler<GetOrganisms, List<Organism>>>();
            Sut = new GetOrganismsQueryHandler(_getAllOrganismsDataQueryHandler);
        }

        [Test]
        public void CanGetAllOrganisms()
        {
            //Assign
            var query = new GetOrganisms();
            //Assign
            var organismOne = new Organism { Id = Guid.NewGuid() };
            var organismTwo = new Organism { Id = Guid.NewGuid() };

            _getAllOrganismsDataQueryHandler.Handle(Arg.Any<GetOrganisms>()).Returns(
                new List<Organism>
                {
                    organismOne,
                    organismTwo
                });

            //Act
            var result = Sut.Handle(query);

            //Assert
            _getAllOrganismsDataQueryHandler.Received().Handle(query);
            result.Should().Contain(organismOne);
            result.Should().Contain(organismTwo);
        }
    }
}
