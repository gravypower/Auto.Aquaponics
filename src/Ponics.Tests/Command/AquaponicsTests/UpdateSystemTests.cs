using NSubstitute;
using NUnit.Framework;
using Ponics.Aquaponics;
using Ponics.Aquaponics.Commands;
using Ponics.Kernel.Commands;

namespace Ponics.Tests.Command.AquaponicsTests
{
    [TestFixture]
    public class UpdateSystemTests
    {
        public UpdateSystemCommandHandler Sut;
        private IDataCommandHandler<UpdateAquaponicSystem> _updateDataCommandHandler;

        [SetUp]
        public void SetUp()
        {
            _updateDataCommandHandler = Substitute.For<IDataCommandHandler<UpdateAquaponicSystem>>();
            Sut = new UpdateSystemCommandHandler(_updateDataCommandHandler);
        }

        [Test]
        public void CanUpdateSystem()
        {
            //Assign
            var command = new UpdateAquaponicSystem();

            //Act
            Sut.Handle(command);

            //Assert
            _updateDataCommandHandler.Received().Handle(command);
        }
    }
}
