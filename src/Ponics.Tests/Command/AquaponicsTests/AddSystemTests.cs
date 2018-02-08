using NSubstitute;
using NUnit.Framework;
using Ponics.Aquaponics;
using Ponics.Aquaponics.Commands;
using Ponics.Aquaponics.Configuration;
using Ponics.Kernel.Commands;

namespace Ponics.Tests.Command.AquaponicsTests
{
    [TestFixture]
    public class AddSystemTests
    {
        public AddAquaponicSystemCommandHandler Sut;
        private IDataCommandHandler<AddAquaponicSystem> _addSystemDataCommandHandler;

        [SetUp]
        public void SetUp()
        {
            _addSystemDataCommandHandler = Substitute.For<IDataCommandHandler<AddAquaponicSystem>>();
            var addAquaponicsSystemConfiguration = Substitute.For<IAddAquaponicsSystemConfiguration>();
            Sut = new AddAquaponicSystemCommandHandler(_addSystemDataCommandHandler, addAquaponicsSystemConfiguration);
        }

        [Test]
        public void SystemAdded()
        {
            //Assign
            var command = new AddAquaponicSystem
            {
                System =  new AquaponicSystem()
            };

            //Act
            Sut.Handle(command);

            //Assert
            _addSystemDataCommandHandler.Received().Handle(Arg.Any<AddAquaponicSystem>());
        }
    }
}
