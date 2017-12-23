using NSubstitute;
using NUnit.Framework;
using Ponics.Kernel.Data;
using Ponics.Organisms;
using Ponics.Organisms.Handlers;

namespace Ponics.Tests.Command
{
    [TestFixture]
    public class UpdateOrganismTests
    {
        public UpdateOrganismCommandHandler Sut;
        private IDataCommandHandler<UpdateOrganism> _updateDataCommandHandler;

        [SetUp]
        public void SetUp()
        {
            _updateDataCommandHandler = Substitute.For<IDataCommandHandler<UpdateOrganism>>();
            Sut = new UpdateOrganismCommandHandler(_updateDataCommandHandler);
        }

        [Test]
        public void CanUpdateSystem()
        {
            //Assign
            var command = new UpdateOrganism();

            //Act
            Sut.Handle(command);

            //Assert
            _updateDataCommandHandler.Received().Handle(command);
        }
    }
}
