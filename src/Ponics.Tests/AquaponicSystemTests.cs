using System;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Ponics.AquaponicSystems;
using Ponics.Components;

namespace Ponics.Tests
{
    [TestFixture]
    public class AquaponicSystemTests
    {
        public AquaponicSystem Sut;

        [SetUp]
        public void SetUp()
        {
            Sut = new AquaponicSystem
            {
                Id = Guid.NewGuid(),
                Name = "AquaponicSystem"
            };
        }

        [Test]
        public void Can_add_Two_Components()
        {
            //Arrange
            var fishTank = Substitute.For<Component>();
            var growBed = Substitute.For<Component>();

            //Act
            Sut.AddComponents(fishTank, growBed);

            //Assert
            Sut.Components.Should().Contain(fishTank);
            Sut.Components.Should().Contain(growBed);
        }

        [Test]
        public void Can_add_Three_Components()
        {
            //Arrange
            var fishTank = Substitute.For<Component>();
            var growBed = Substitute.For<Component>();
            var sumpTank = Substitute.For<Component>();

            //Act
            Sut.AddComponents(fishTank, growBed, sumpTank);

            //Assert
            Sut.Components.Should().Contain(fishTank);
            Sut.Components.Should().Contain(growBed);
            Sut.Components.Should().Contain(sumpTank);
        }

        [Test]
        public void Given_Three_Components_Added_Then_Component_connections_are_correct()
        {
            //Arrange
            var fishTank = Substitute.For<Component>();
            fishTank.Name = "fishTank";
            fishTank.Id = Guid.NewGuid();

            var growBed = Substitute.For<Component>();
            growBed.Name = "growBed";
            growBed.Id = Guid.NewGuid();

            var sumpTank = Substitute.For<Component>();
            sumpTank.Name = "sumpTank";
            sumpTank.Id = Guid.NewGuid();

            //Act
            Sut.AddComponents(fishTank, growBed, sumpTank);

            //Assert
            Sut.ComponentConnections.Should().Contain(c => c.SourceId == fishTank.Id && c.TargetId == growBed.Id);
            Sut.ComponentConnections.Should().Contain(c => c.SourceId == growBed.Id && c.TargetId == sumpTank.Id);
            Sut.ComponentConnections.Should().Contain(c => c.SourceId == sumpTank.Id && c.TargetId == fishTank.Id);
        }

        [Test]
        public void Given_Three_Components_Added_And_system_is_unclosed_Then_Component_connections_are_correct()
        {
            //Arrange
            Sut.Closed = false;
            var fishTank = Substitute.For<Component>();
            fishTank.Name = "fishTank";
            fishTank.Id = Guid.NewGuid();

            var growBed = Substitute.For<Component>();
            growBed.Name = "growBed";
            growBed.Id = Guid.NewGuid();

            var sumpTank = Substitute.For<Component>();
            sumpTank.Name = "sumpTank";
            sumpTank.Id = Guid.NewGuid();

            //Act
            Sut.AddComponents(fishTank, growBed, sumpTank);

            //Assert
            Sut.ComponentConnections.Should().Contain(c => c.SourceId == fishTank.Id && c.TargetId == growBed.Id);
            Sut.ComponentConnections.Should().Contain(c => c.SourceId == growBed.Id && c.TargetId == sumpTank.Id);
            Sut.ComponentConnections.Should().NotContain(c => c.SourceId == sumpTank.Id && c.TargetId == fishTank.Id);
        }


        [Test]
        public void Given_Three_Components_Added_and_system_is_not_closed_Then_Component_connections_are_correct()
        {
            //Arrange
            Sut = new AquaponicSystem
            {
                Id = Guid.NewGuid(),
                Name = "AquaponicSystem",
                Closed = false
            };
            var fishTank = Substitute.For<Component>();
            fishTank.Name = "fishTank";
            fishTank.Id = Guid.NewGuid();

            var growBed = Substitute.For<Component>();
            growBed.Name = "growBed";
            growBed.Id = Guid.NewGuid();

            var sumpTank = Substitute.For<Component>();
            sumpTank.Name = "sumpTank";
            sumpTank.Id = Guid.NewGuid();

            //Act
            Sut.AddComponents(fishTank, growBed, sumpTank);

            //Assert
            Sut.ComponentConnections.Should().Contain(c => c.SourceId == fishTank.Id && c.TargetId == growBed.Id);
            Sut.ComponentConnections.Should().Contain(c => c.SourceId == growBed.Id && c.TargetId == sumpTank.Id);
            Sut.ComponentConnections.Should().NotContain(c => c.SourceId == sumpTank.Id && c.TargetId == fishTank.Id);
        }
    }
}

