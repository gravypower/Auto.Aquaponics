using NSubstitute;
using NUnit.Framework;
using Ponics.AquaponicSystems;
using Ponics.AquaponicSystems.Handlers;
using Ponics.Kernel.Data;

namespace Ponics.Tests.Command
{
    [TestFixture]
    public class UpdateSystemTests
    {
        public UpdateSystemCommandHandler Sut;
        private IDataCommandHandler<UpdateSystem> _updateDataCommandHandler;

        [SetUp]
        public void SetUp()
        {
            _updateDataCommandHandler = Substitute.For<IDataCommandHandler<UpdateSystem>>();
            Sut = new UpdateSystemCommandHandler(_updateDataCommandHandler);
        }

        [Test]
        public void CanUpdateSystem()
        {
            //Assign
            var command = new UpdateSystem();

            //Act
            Sut.Handle(command);

            //Assert
            _updateDataCommandHandler.Received().Handle(command);
        }
    }
}
