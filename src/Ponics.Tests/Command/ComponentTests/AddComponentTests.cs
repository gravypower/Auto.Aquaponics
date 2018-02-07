using System;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Ponics.Aquaponics;
using Ponics.Aquaponics.Commands;
using Ponics.Aquaponics.Queries;
using Ponics.Components;
using Ponics.Components.Commands;
using Ponics.Tests.Command.AquaponicsTests;

namespace Ponics.Tests.Command.ComponentTests
{
    [TestFixture]
    public class AddComponentTests : MutateSystemTests<AddComponentCommandHandler>
    {
        [SetUp]
        public void AddComponentSetUp()
        {
            Sut = new AddComponentCommandHandler(UpdateSystemDataCommandHandler, GetSystemDataCommandHandler);
        }

        [Test]
        public void CanAddComponent()
        {
            //Assign
            var component = new Ponics.Components.Component();
            var command = new AddComponent
            {
                Component = component,
                SystemId = Guid.NewGuid()
            };

            //Act
            Sut.Handle(command);

            //Assert
            UpdateSystemDataCommandHandler.Received().Handle(
                Arg.Is<UpdateAquaponicSystem>(
                    c => c.System.Components.Contains(component)));

            UpdateSystemDataCommandHandler.Received().Handle(
                Arg.Is<UpdateAquaponicSystem>(
                    c => c.SystemId == command.SystemId));
        }

        [Test]
        public void ComponentAdded_Id_Generated()
        {
            //Assign
            var component = new Ponics.Components.Component();
            var command = new AddComponent { Component = component };

            //Act
            Sut.Handle(command);

            //Assert
            command.Component.Id.Should().NotBe(Guid.Empty);
        }

        [Test]
        public void System_Loaded()
        {
            //Assign
            var component = new Ponics.Components.Component();
            var systemId = Guid.NewGuid();
            var command = new AddComponent
            {
                Component = component,
                SystemId = systemId
            };

            //Act
            Sut.Handle(command);

            //Assert
            GetSystemDataCommandHandler.Received().Handle(Arg.Is<GetAquaponicSystem>(
                c => c.SystemId == systemId
            ));
        }

        [Test]
        public void Can_add_Two_Components()
        {
            //Arrange
            var fishTank = Substitute.For<Ponics.Components.Component>();
            var growBed = Substitute.For<Ponics.Components.Component>();

            var addFishTankCommand = new AddComponent { Component = fishTank };
            var addGrowBedCommand = new AddComponent { Component = growBed };

            //Act
            Sut.Handle(addFishTankCommand);
            Sut.Handle(addGrowBedCommand);

            //Assert
            AquaponicSystem.Components.Should().Contain(fishTank);
            AquaponicSystem.Components.Should().Contain(growBed);
        }

        [Test]
        public void Can_add_Three_Components()
        {

            //Arrange
            var fishTank = Substitute.For<Ponics.Components.Component>();
            var growBed = Substitute.For<Ponics.Components.Component>();
            var sumpTank = Substitute.For<Ponics.Components.Component>();


            var addFishTankCommand = new AddComponent { Component = fishTank };
            var addGrowBedCommand = new AddComponent { Component = growBed };
            var addSumpTankCommand = new AddComponent { Component = sumpTank };

            //Act
            Sut.Handle(addFishTankCommand);
            Sut.Handle(addGrowBedCommand);
            Sut.Handle(addSumpTankCommand);

            //Assert
            AquaponicSystem.Components.Should().Contain(fishTank);
            AquaponicSystem.Components.Should().Contain(growBed);
            AquaponicSystem.Components.Should().Contain(sumpTank);
        }
    }
}
