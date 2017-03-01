using System;
using System.Collections.Generic;
using Auto.Aquaponics.Components;
using Auto.Aquaponics.Kernel.GraphTheory.Graphs;
using Auto.Aquaponics.Kernel.Query;
using Auto.Aquaponics.Organisms;
using Auto.Aquaponics.Query.LevelAnalysis;
using Auto.Aquaponics.Query.LevelAnalysis.Ph;
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
        private IDictionary<Type, IQueryHandler<LevelAnalysisQuery, LevelAnalysisResult>> _levelAnalysisQueryHandleres;

        [SetUp]
        public void SetUp()
        {
            _levelAnalysisQueryHandleres = new Dictionary<Type, IQueryHandler<LevelAnalysisQuery, LevelAnalysisResult>>();
            _graph = new DirectedAcyclicGraph<Component>();

            Sut = new AquaponicSystem(_graph, _levelAnalysisQueryHandleres);
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

        [Test]
        public void SomeTEst()
        {
            //Arrange
            var fishTank = Substitute.For<Component>();
            var silverPerch = Substitute.For<Organism>();
            fishTank.AddOrganisms(silverPerch);

            var growBed = Substitute.For<Component>();
            var strawberry = Substitute.For<Organism>();
            growBed.AddOrganisms(strawberry);

            var sumpTank = Substitute.For<Component>();
            var goldFish = Substitute.For<Organism>();
            sumpTank.AddOrganisms(goldFish);

            Sut.AddComponents(fishTank, growBed, sumpTank);

            var queryHandler = Substitute.For<IQueryHandler<LevelAnalysisQuery, LevelAnalysisResult>>();
            _levelAnalysisQueryHandleres.Add(typeof(PhLevelAnalysis), queryHandler);

            //Act
            var results = Sut.RunAnalysis<PhLevelAnalysis>(0);

            //Assert
            queryHandler.Received().Handle(Arg.Any<PhLevelAnalysis>());
            results.Keys.Count.Should().Be(3);
        }
    }
}
