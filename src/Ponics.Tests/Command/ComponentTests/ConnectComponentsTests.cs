using System;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Ponics.Aquaponics;
using Ponics.Components;
using Ponics.Tests.Command.AquaponicsTests;

namespace Ponics.Tests.Command.ComponentTests
{
    [TestFixture]
    public class ConnectComponentsTests: MutateSystemTests<ConnectComponentsCommandHandler>
    {
        [SetUp]
        public void ConnectComponentsSetUp()
        {
            Sut = new ConnectComponentsCommandHandler(UpdateSystemDataCommandHandler, GetSystemDataCommandHandler);
        }

        [Test]
        public void CanAddComponentConnection()
        {
            //Assign
            var componentConnection = new ComponentConnection();
            var command = new ConnectComponents { ComponentConnection = componentConnection };

            //Act
            Sut.Handle(command);

            //Assert
            UpdateSystemDataCommandHandler.Received().Handle(
                Arg.Is<UpdateSystem>(
                    c => c.System.ComponentConnections.Contains(componentConnection)));
        }

        [Test]
        public void System_Loaded()
        {
            //Assign
            var systemId = Guid.NewGuid();
            var command = new ConnectComponents
            {
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
        public void Given_Three_Components_Added_Then_Component_connections_are_correct()
        {
            //Arrange
            var fishTank = Substitute.For<Ponics.Components.Component>();
            fishTank.Name = "fishTank";
            fishTank.Id = Guid.NewGuid();

            var growBed = Substitute.For<Ponics.Components.Component>();
            growBed.Name = "growBed";
            growBed.Id = Guid.NewGuid();

            var sumpTank = Substitute.For<Ponics.Components.Component>();
            sumpTank.Name = "sumpTank";
            sumpTank.Id = Guid.NewGuid();

            var connectFishTankAndGrowBedCommand = new ConnectComponents
            {
                ComponentConnection = new ComponentConnection
                {
                    SourceId = fishTank.Id,
                    TargetId = growBed.Id
                }
            };

            var connectGrowBedAndSumpTankCommand = new ConnectComponents
            {
                ComponentConnection = new ComponentConnection
                {
                    SourceId = growBed.Id,
                    TargetId = sumpTank.Id
                }
            };

            var connectSumpTankAndFishTankCommand = new ConnectComponents
            {
                ComponentConnection = new ComponentConnection
                {
                    SourceId = sumpTank.Id,
                    TargetId = fishTank.Id
                }
            };

            //Act
            Sut.Handle(connectFishTankAndGrowBedCommand);
            Sut.Handle(connectGrowBedAndSumpTankCommand);
            Sut.Handle(connectSumpTankAndFishTankCommand);

            //Assert
            AquaponicSystem.ComponentConnections.Should().Contain(c => c.SourceId == fishTank.Id && c.TargetId == growBed.Id);
            AquaponicSystem.ComponentConnections.Should().Contain(c => c.SourceId == growBed.Id && c.TargetId == sumpTank.Id);
            AquaponicSystem.ComponentConnections.Should().Contain(c => c.SourceId == sumpTank.Id && c.TargetId == fishTank.Id);
        }
    }
}
