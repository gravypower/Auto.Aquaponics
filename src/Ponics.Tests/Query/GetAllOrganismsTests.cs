
using System;
using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Ponics.Kernel.Data;
using Ponics.Organisms;
using Ponics.Organisms.Handlers;

namespace Ponics.Tests.Query
{
    [TestFixture]
    public class GetAllOrganismsTests
    {
        public GetAllOrganismsQueryHandler Sut;
        private IDataQueryHandler<GetAllOrganisms, List<Organism>> _getAllOrganismsDataQueryHandler;

        [SetUp]
        public void SetUp()
        {
            _getAllOrganismsDataQueryHandler = Substitute.For<IDataQueryHandler<GetAllOrganisms, List<Organism>>>();
            Sut = new GetAllOrganismsQueryHandler(_getAllOrganismsDataQueryHandler);
        }

        [Test]
        public void CanGetAllOrganisms()
        {
            //Assign
            var query = new GetAllOrganisms();
            //Assign
            var organismOne = new Organism { Id = Guid.NewGuid() };
            var organismTwo = new Organism { Id = Guid.NewGuid() };

            _getAllOrganismsDataQueryHandler.Handle(Arg.Any<GetAllOrganisms>()).Returns(
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
