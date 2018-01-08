using System;
using System.Collections.Generic;
using NodaTime;
using NSubstitute;
using NUnit.Framework;
using Ponics.Analysis.Levels;
using Ponics.Commands;
using Ponics.Kernel.Commands;

namespace Ponics.Tests.Command
{
    [TestFixture]
    public class LevelReadingTests
    {
        public AddLevelReadingCommandHandler Sut;
        private IDataCommandHandler<AddLevelReading> _addLevelReadingDataCommandHandler;

        [SetUp]
        public void SetUp()
        {
            _addLevelReadingDataCommandHandler = Substitute.For<IDataCommandHandler<AddLevelReading>>();
            Sut = new AddLevelReadingCommandHandler(_addLevelReadingDataCommandHandler);
        }

        [Test]
        public void CanAddLevelReading()
        {
            //Assign
            var command = new AddLevelReading
            {
                SystemId = Guid.NewGuid(),
                LevelReadings =
                    new List<LevelReading>
                    {
                        new LevelReading
                        {
                            Type = "test",
                            Value = 1,
                            DateTime = new ZonedDateTime(Instant.MaxValue, DateTimeZone.Utc)
                        }
                    }
            };

        //Act
            Sut.Handle(command);

            //Assert
            _addLevelReadingDataCommandHandler.Received().Handle(Arg.Any<AddLevelReading>());
        }
    }
}
