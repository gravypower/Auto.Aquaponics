using System;
using NSubstitute;
using NUnit.Framework;
using Ponics.AquaponicSystems;
using Ponics.AquaponicSystems.Handlers;
using Ponics.Kernel.Data;

namespace Ponics.Tests.Command
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
               Id = Guid.NewGuid()
            };

            //Act
            Sut.Handle(command);

            //Assert
            _addSystemDataCommandHandler.Received().Handle(Arg.Any<DeleteSystem>());
        }

    }
}
