using System;
using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Ponics.Analysis.Levels;
using Ponics.Analysis.Levels.MagicStrings;
using Ponics.Kernel.Data;
using Ponics.Organisms;

namespace Ponics.Tests.Command
{
    [TestFixture]
    public class AddToleranceTests
    {
        private IDataQueryHandler<GetAllOrganisms, List<Organism>> _getAllOrganismsDataQueryHandler;
        private Organism _organism;
        private MockTolerance _mockTolerance;
        private AddTolerance<MockTolerance> _addTolerance;
        private IDataCommandHandler<UpdateOrganism> _updateOrganismDataCommandHandler;


        public AddToleranceCommandHandler<MockTolerance> Sut { get; set; }

        [SetUp]
        public void SetUp()
        {
            var toleranceMagicStrings = new ToleranceMagicStrings();

            _getAllOrganismsDataQueryHandler = Substitute.For<IDataQueryHandler<GetAllOrganisms, List<Organism>>>();
            _updateOrganismDataCommandHandler = Substitute.For<IDataCommandHandler<UpdateOrganism>>();

            Sut = new AddToleranceCommandHandler<MockTolerance>(
                _getAllOrganismsDataQueryHandler, 
                _updateOrganismDataCommandHandler, 
                toleranceMagicStrings);

            _organism = new Organism
            {
                Id = Guid.NewGuid()
            };

            _getAllOrganismsDataQueryHandler.Handle(Arg.Any<GetAllOrganisms>()).Returns(new List<Organism> { _organism });

            _mockTolerance = new MockTolerance();
            _addTolerance = Substitute.For<AddTolerance<MockTolerance>>();
            _addTolerance.OrganismId = _organism.Id;
            _addTolerance.Tolerance.Returns(_mockTolerance);
        }

        [Test]
        public void Add_Tolerance_Organism_Updated()
        {
            //Act
            Sut.Handle(_addTolerance);

            //Assert
            _organism.Tolerances.Should().Contain(_mockTolerance);
        }

        [Test]
        public void Adding_Two_ToleranceOfSameType_ToleranceExistsException_thrown()
        {
            //Arrange
            _organism.Tolerances.Add(_mockTolerance);

            //Act
            void Act() => Sut.Handle(_addTolerance);

            //Assert
            AssertInvalidOperationException(Act, "Tolerance already defined for organism");
        }


        protected static void AssertInvalidOperationException(Action act, string message)
        {
            act.ShouldThrow<InvalidOperationException>()
                .WithMessage($"{message}");
        }
    }
}
