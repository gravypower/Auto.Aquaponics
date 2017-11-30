using System;
using Auto.Aquaponics.AquaponicSystems;
using Auto.Aquaponics.Components;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Auto.Aquaponics.Tests
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

            var growBed = Substitute.For<Component>();
            growBed.Name = "growBed";

            var sumpTank = Substitute.For<Component>();
            sumpTank.Name = "sumpTank";

            //Act
            Sut.AddComponents(fishTank, growBed, sumpTank);

            //Assert
            Sut.ComponentConnections.Should().Contain(c=>c.SourceId == "fishTank" && c.TargetId == "growBed");
            Sut.ComponentConnections.Should().Contain(c => c.SourceId == "growBed" && c.TargetId == "sumpTank");
            Sut.ComponentConnections.Should().Contain(c => c.SourceId == "sumpTank" && c.TargetId == "fishTank");
        }

        [Test]
        public void Given_Three_Components_Added_And_system_is_unclosed_Then_Component_connections_are_correct()
        {
            //Arrange
            Sut.Closed = false;
            var fishTank = Substitute.For<Component>();
            fishTank.Name = "fishTank";

            var growBed = Substitute.For<Component>();
            growBed.Name = "growBed";

            var sumpTank = Substitute.For<Component>();
            sumpTank.Name = "sumpTank";

            //Act
            Sut.AddComponents(fishTank, growBed, sumpTank);

            //Assert
            Sut.ComponentConnections.Should().Contain(c => c.SourceId == "fishTank" && c.TargetId == "growBed");
            Sut.ComponentConnections.Should().Contain(c => c.SourceId == "growBed" && c.TargetId == "sumpTank");
            Sut.ComponentConnections.Should().NotContain(c => c.SourceId == "sumpTank" && c.TargetId == "fishTank");
        }


        [Test]
        public void Given_Three_Components_Added_and_system_is_not_closed_Then_Component_connections_are_correct()
        {
            //Arrange
            Sut = new AquaponicSystem {Id = Guid.NewGuid(), Name = "AquaponicSystem", Closed = false};
            var fishTank = Substitute.For<Component>();
            fishTank.Name = "fishTank";

            var growBed = Substitute.For<Component>();
            growBed.Name = "growBed";

            var sumpTank = Substitute.For<Component>();
            sumpTank.Name = "sumpTank";

            //Act
            Sut.AddComponents(fishTank, growBed, sumpTank);

            //Assert
            Sut.ComponentConnections.Should().Contain(c => c.SourceId == "fishTank" && c.TargetId == "growBed");
            Sut.ComponentConnections.Should().Contain(c => c.SourceId == "growBed" && c.TargetId == "sumpTank");
            Sut.ComponentConnections.Should().NotContain(c => c.SourceId == "sumpTank" && c.TargetId == "fishTank");
        }
    }
}
