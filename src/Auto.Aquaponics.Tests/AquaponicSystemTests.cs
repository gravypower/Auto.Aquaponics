using Auto.Aquaponics.Components;
using Auto.Aquaponics.Kernel.GraphTheory.Graphs;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Auto.Aquaponics.Tests
{
    [TestFixture]
    public class AquaponicSystemTests
    {
        public AquaponicSystem Sut;
        private IGraph<Component> _graph;


        [SetUp]
        public void SetUp()
        {
            _graph = new DirectedAcyclicGraph<Component>();

            Sut = new AquaponicSystem(_graph);
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
            _graph.VerticesAndEdges.Keys.Should().Contain(fishTank);
            _graph.VerticesAndEdges.Keys.Should().Contain(growBed);

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
            _graph.VerticesAndEdges.Keys.Should().Contain(fishTank);
            _graph.VerticesAndEdges.Keys.Should().Contain(growBed);
            _graph.VerticesAndEdges.Keys.Should().Contain(sumpTank);
        }
    }
}
