using System.Linq;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Ponics.Analysis.Levels.Commands;
using Ponics.Analysis.Levels.Handlers;
using Ponics.Organisms;

namespace Ponics.Tests.Command.ToleranceTests
{
    [TestFixture]
    public class UpdateToleranceTests : ToleranceTests<MockTolerance, UpdateTolerance<MockTolerance>, UpdateToleranceCommandHandler<MockTolerance>>
    {
        [SetUp]
        public void SetUp()
        {
          Sut = new UpdateToleranceCommandHandler<MockTolerance>(
              GetAllOrganismsDataQueryHandler,
              UpdateOrganismDataCommandHandler,
              ToleranceMagicStrings);

            MockTolerance.DesiredLower = 10;
            Organism.Tolerances.Add(MockTolerance);

        }

        [Test]
        public void Tolerance_Updated()
        {
            //Arrange
            var command = Substitute.For<UpdateTolerance<MockTolerance>>();
            command.OrganismId = Organism.Id;
            command.Tolerance.Returns(new MockTolerance
            {
               DesiredLower = 20
            });

            //Act
            Sut.Handle(command);

            //Assert
            Organism.Tolerances.Single(t => t.GetType() == typeof(MockTolerance)).DesiredLower.Should().Be(20);
            UpdateOrganismDataCommandHandler.Received().Handle(Arg.Any<UpdateOrganism>());
        }
    }
}
