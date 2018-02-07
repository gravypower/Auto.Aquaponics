using System;
using NSubstitute;
using NUnit.Framework;
using Ponics.Aquaponics;
using Ponics.Aquaponics.Commands;
using Ponics.Commands;
using Ponics.Kernel.Commands;

namespace Ponics.Tests.Command.AquaponicsTests
{
    [TestFixture]
    public class DeleteSystemTests
    {
        public DeleteSystemCommandHandler Sut;
        private IDataCommandHandler<DeleteSystem> _addSystemDataCommandHandler;

        [SetUp]
        public void SetUp()
        {
            _addSystemDataCommandHandler = Substitute.For<IDataCommandHandler<DeleteSystem>>();
            Sut = new DeleteSystemCommandHandler(_addSystemDataCommandHandler);
        }

        [Test]
        public void CanDeletedSystem()
        {
            //Assign
            var command = new DeleteSystem
            {
               SystemId = Guid.NewGuid()
            };

            //Act
            Sut.Handle(command);

            //Assert
            _addSystemDataCommandHandler.Received().Handle(Arg.Any<DeleteSystem>());
        }

    }
}
