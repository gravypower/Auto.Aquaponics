using Auto.Aquaponics.Analysis.Level;
using Auto.Aquaponics.Analysis.System;
using Auto.Aquaponics.AquaponicSystems;
using Auto.Aquaponics.Components;
using Auto.Aquaponics.HardCodedData.Organisms;
using Auto.Aquaponics.Query;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Auto.Aquaponics.Tests.Query.System
{
    [TestFixture]
    public class SystemAnalysisHandlerTests
    {
        protected SystemAnalysisHandler Sut;
        protected IQueryProcessor QueryProcessor;
        protected AquaponicSystem System;

        [SetUp]
        protected void SetUp()
        {
            QueryProcessor = Substitute.For<IQueryProcessor>();
            Sut = new SystemAnalysisHandler(QueryProcessor);
            System = new AquaponicSystem("SomeName");
        }

        [Test]
        public void Result_shoud_contain_component()
        {
            //Arrange
            var fishTank = Substitute.For<Component>();
            var growBed = Substitute.For<Component>();
            var sumpTank = Substitute.For<Component>();
            System.AddComponents(fishTank, growBed, sumpTank);

            var query = Substitute.For<LevelAnalysisQuery<LevelAnalysis>>();
            var systemQuery = new SystemAnalysisQuery(System, query);

            //Act
            var result = Sut.Handle(systemQuery);

            //Assert
            result.Results.Should().ContainKey(fishTank);
            result.Results.Should().ContainKey(growBed);
            result.Results.Should().ContainKey(sumpTank);

        }

        [Test]
        public void Result_shoud_contain_Organism()
        {
            //Arrange
            var fishTank = new Component("fishTank");
            var silverPerch = new SilverPerch();
            fishTank.AddOrganisms(silverPerch);

            System.AddComponents(fishTank);

            var query = Substitute.For<LevelAnalysisQuery<LevelAnalysis>>();
            var systemQuery = new SystemAnalysisQuery(System, query);

            //Act
            var result = Sut.Handle(systemQuery);

            //Assert
            result.Results[fishTank].Keys.Should().Contain(silverPerch);
        }

        [Test]
        public void Result_shoud_contain_Analysis()
        {
            //Arrange
            var fishTank = new Component("fishTank");
            var silverPerch = new SilverPerch();
            fishTank.AddOrganisms(silverPerch);

            System.AddComponents(fishTank);

            var query = Substitute.For<LevelAnalysisQuery<LevelAnalysis>>();

            var systemQuery = new SystemAnalysisQuery(System, query);

            var levelAnalysis = Substitute.For<LevelAnalysis> ();

            QueryProcessor.Process<LevelAnalysisQuery<LevelAnalysis>, LevelAnalysis>(Arg.Any<LevelAnalysisQuery<LevelAnalysis>>()).Returns(levelAnalysis);

            //Act
            var result = Sut.Handle(systemQuery);

            //Assert
            result.Results[fishTank][silverPerch].Should().Contain(levelAnalysis);
        }
    }
}
