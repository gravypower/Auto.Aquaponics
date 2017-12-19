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
    public class GetOrganismTests
    {
        public GetOrganismQueryHandler Sut;
        private IDataQueryHandler<GetAllOrganisms, List<Organism>> _getAllOrganismsDataQueryHandler;

        [SetUp]
        public void SetUp()
        {
            _getAllOrganismsDataQueryHandler = Substitute.For<IDataQueryHandler<GetAllOrganisms, List<Organism>>>();
            Sut = new GetOrganismQueryHandler(_getAllOrganismsDataQueryHandler);
        }

        [Test]
        public void CanGetOrganisms()
        {
            //Assign
            var organism = new Organism{ Id = Guid.NewGuid() };
            var query = new GetOrganism { Id = organism.Id };

            _getAllOrganismsDataQueryHandler.Handle(Arg.Any<GetAllOrganisms>()).Returns(
                new List<Organism>
                {
                    new Organism(),
                    organism
                });

            //Act
            var result = Sut.Handle(query);

            //Assert
            _getAllOrganismsDataQueryHandler.Received().Handle(Arg.Any<GetAllOrganisms>());
            result.Should().Be(organism);
        }
    }
}
