using NSubstitute;
using NUnit.Framework;
using Ponics.AquaponicSystems;
using Ponics.Kernel.Data;

namespace Ponics.Tests.Command
{
    [TestFixture]
    public class AddSystemTests
    {
        public AddSystemCommandHandler Sut;
        private IDataCommandHandler<AddSystem> _addSystemDataCommandHandler;

        [SetUp]
        public void SetUp()
        {
            _addSystemDataCommandHandler = Substitute.For<IDataCommandHandler<AddSystem>>();
            Sut = new AddSystemCommandHandler(_addSystemDataCommandHandler);
        }

        [Test]
        public void SystemAdded()
        {
            //Assign
            var command = new AddSystem
            {
                System =  new AquaponicSystem()
            };

            //Act
            Sut.Handle(command);

            //Assert
            _addSystemDataCommandHandler.Received().Handle(Arg.Any<AddSystem>());
        }
    }
}
