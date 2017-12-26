using System;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Ponics.Analysis.Levels.Commands;
using Ponics.Analysis.Levels.Handlers;
using Ponics.Organisms;

namespace Ponics.Tests.Command.ToleranceTests
{
    [TestFixture]
    public class AddToleranceTests : ToleranceTests<MockTolerance, AddTolerance<MockTolerance>, AddToleranceCommandHandler<MockTolerance>>
    {
        protected AddTolerance<MockTolerance> AddTolerance;

        [SetUp]
        public void SetUp()
        {
            Sut = new AddToleranceCommandHandler<MockTolerance>(
                GetAllOrganismsDataQueryHandler,
                UpdateOrganismDataCommandHandler,
                ToleranceMagicStrings);

            AddTolerance = Substitute.For<AddTolerance<MockTolerance>>();
            AddTolerance.OrganismId = Organism.Id;
            AddTolerance.Tolerance.Returns(MockTolerance);
        }

        [Test]
        public void Add_Tolerance_Organism_Updated()
        {
            //Act
            Sut.Handle(AddTolerance);

            //Assert
            Organism.Tolerances.Should().Contain(MockTolerance);
            UpdateOrganismDataCommandHandler.Received().Handle(Arg.Any<UpdateOrganism>());
        }

        [Test]
        public void Adding_Two_ToleranceOfSameType_ToleranceExistsException_thrown()
        {
            //Arrange
            Organism.Tolerances.Add(MockTolerance);

            //Act
            void Act() => Sut.Handle(AddTolerance);

            //Assert
            AssertInvalidOperationException(Act, "Tolerance already defined for organism");
        }

        [Test]
        public void CanNotAdd_An_UndefinedTolerance()
        {
            //Assign
            AddTolerance.Tolerance = null;

            // Act
            void Act() => Sut.Handle(AddTolerance);

            //Assert
            AssertInvalidOperationException(Act, "Can not add an Undefined Tolerance");
        }



        protected static void AssertInvalidOperationException(Action act, string message)
        {
            act.ShouldThrow<InvalidOperationException>()
                .WithMessage($"{message}");
        }
    }
}
