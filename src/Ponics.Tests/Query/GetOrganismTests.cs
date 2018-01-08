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
    public class GetOrganismTests
    {
        public GetOrganismQueryHandler Sut;
        private IDataQueryHandler<GetOrganisms, List<Organism>> _getAllOrganismsDataQueryHandler;

        [SetUp]
        public void SetUp()
        {
            _getAllOrganismsDataQueryHandler = Substitute.For<IDataQueryHandler<GetOrganisms, List<Organism>>>();
            Sut = new GetOrganismQueryHandler(_getAllOrganismsDataQueryHandler);
        }

        [Test]
        public void CanGetOrganisms()
        {
            //Assign
            var organism = new Organism{ Id = Guid.NewGuid() };
            var query = new GetOrganism { OrganismId = organism.Id };

            _getAllOrganismsDataQueryHandler.Handle(Arg.Any<GetOrganisms>()).Returns(
                new List<Organism>
                {
                    new Organism(),
                    organism
                });

            //Act
            var result = Sut.Handle(query);

            //Assert
            _getAllOrganismsDataQueryHandler.Received().Handle(Arg.Any<GetOrganisms>());
            result.Should().Be(organism);
        }
    }
}
