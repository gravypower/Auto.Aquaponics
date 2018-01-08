using System;
using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Ponics.Aquaponics;
using Ponics.Aquaponics.Queries;
using Ponics.Kernel.Commands;
using Ponics.Kernel.Queries;
using Ponics.Organisms;
using Ponics.Organisms.Commands;

namespace Ponics.Tests.Command.OrganismTests
{
    [TestFixture]
    public class DeleteOrganismTests
    {
        public DeleteOrganismCommandHandler Sut;
        private IDataCommandHandler<DeleteOrganism> _deleteOrganismDataCommandHandler;
        private IDataQueryHandler<GetAllSystems, List<AquaponicSystem>> _getAllSystemsDataQueryHandler;


        [SetUp]
        public void SetUp()
        {
            _getAllSystemsDataQueryHandler = Substitute.For<IDataQueryHandler<GetAllSystems, List<AquaponicSystem>>>();
            _deleteOrganismDataCommandHandler = Substitute.For<IDataCommandHandler<DeleteOrganism>>();
            Sut = new DeleteOrganismCommandHandler(_deleteOrganismDataCommandHandler, _getAllSystemsDataQueryHandler);
        }

        [Test]
        public void CanDeleteOrganism()
        {
            //Assign
            var command = new DeleteOrganism();

            //Act
            Sut.Handle(command);

            //Assert
            _deleteOrganismDataCommandHandler.Received().Handle(command);
        }

        [Test]
        public void GivenOrganismInASystem_WhenDeleteAttempted_ExceptionThrown()
        {
            //Assign
            var organism = new Organisms.Organism
            {
                Id = Guid.NewGuid()
            };

            var command = new DeleteOrganism {OrganismId = organism.Id};

            var system = new AquaponicSystem();
            var component = new Ponics.Components.Component();
            component.AddOrganisms(organism.Id);
            system.Components.Add(component);
            _getAllSystemsDataQueryHandler.Handle(Arg.Any<GetAllSystems>()).Returns(
                new List<AquaponicSystem>
                {
                    system
                }
            );

            //Act
            Action act = () => Sut.Handle(command);

            //Assert
            act.ShouldThrow<OrganismReferencedException>();

        }
    }
}
