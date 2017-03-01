using Auto.Aquaponics.Kernel.Tests.Query;
using FluentAssertions;
using NUnit.Framework;

namespace Auto.Aquaponics.Kernel.Tests.Persistence
{
    [TestFixture]
    public class QueryMementoTests
    {
        public MockQueryMemento Sut;

        [SetUp]
        public void SetUp()
        {
            Sut = new MockQueryMemento();
        }

        [Test]
        public void can_save_query()
        {
            //Arrange
            var key = "SomeKey";
            var query = new MockQuery( key);

            //Act
            Sut.Save(query);

            //Assert
            var type = typeof(MockQuery).FullName;
            Sut.Persistence.Should().ContainKey(key, $"this should happend in the {key} system");
        }

        [Test]
        public void can_load_query()
        {
            //Arrange
            var key = "SomeKey";
            var query = new MockQuery(key);
            Sut.Save(query);

            //Act
            var result = Sut.Load<MockQuery>(typeof(MockQuery).FullName, key);

            //Assert
            result.ShouldBeEquivalentTo(query);
        }
    }
}
