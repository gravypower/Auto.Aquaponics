using System;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Ponics.AquaponicSystems;
using Ponics.Components;

namespace Ponics.Tests.Command
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
            var component = new Component();
            var command = new AddComponent
            {
                Component = component,
                SystemId = Guid.NewGuid()
            };

            //Act
            Sut.Handle(command);

            //Assert
            UpdateSystemDataCommandHandler.Received().Handle(
                Arg.Is<UpdateSystem>(
                    c => c.System.Components.Contains(component)));

            UpdateSystemDataCommandHandler.Received().Handle(
                Arg.Is<UpdateSystem>(
                    c => c.Id == command.SystemId));
        }

        [Test]
        public void ComponentAdded_Id_Generated()
        {
            //Assign
            var component = new Component();
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
            var component = new Component();
            var systemId = Guid.NewGuid();
            var command = new AddComponent
            {
                Component = component,
                SystemId = systemId
            };

            //Act
            Sut.Handle(command);

            //Assert
            GetSystemDataCommandHandler.Received().Handle(Arg.Is<GetSystem>(
                c => c.Id == systemId
            ));
        }

        [Test]
        public void Can_add_Two_Components()
        {
            //Arrange
            var fishTank = Substitute.For<Component>();
            var growBed = Substitute.For<Component>();

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
            var fishTank = Substitute.For<Component>();
            var growBed = Substitute.For<Component>();
            var sumpTank = Substitute.For<Component>();


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
