using Ponics.Organisms;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using Ponics.Components;

namespace Ponics.Tests.Components
{
    [TestFixture]
    public class ComponentTests
    {
        public Component Sut;

        [SetUp]
        public void SetUp()
        {
            Sut = Substitute.For<Component>();
        }

        [Test]
        public void Can_Add_Organism()
        {
            //Arrange
            var organism = Guid.NewGuid();

            //Act
            Sut.AddOrganisms(organism);

            //Assert
            Sut.Organisms.Should().Contain(organism);
        }

        [Test]
        public void Can_Add_Organisms()
        {
            //Arrange
            var fish = Guid.NewGuid();
            var plant = Guid.NewGuid();

            //Act
            Sut.AddOrganisms(fish, plant);

            //Assert
            Sut.Organisms.Should().Contain(fish);
            Sut.Organisms.Should().Contain(plant);
        }
    }
}
