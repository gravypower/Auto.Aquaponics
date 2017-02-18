using Auto.Aquaponics.Kernel.Tests.Query;
using FluentAssertions;
using NSubstitute;
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
            var systemKey = "SomeSystem";
            var key = "SomeKey";
            var query = new MockQuery(systemKey, key);

            //Act
            Sut.Save(query);

            //Assert
            var type = typeof(MockQuery).FullName;
            Sut.Persistence.Should().ContainKey(systemKey, $"this should happend in the {systemKey} system");
            Sut.Persistence[systemKey].Should().ContainKey(type);
            Sut.Persistence[systemKey][type].Should().ContainKey(key);
        }

        [Test]
        public void can_load_query()
        {
            //Arrange
            var key = "SomeKey";
            var systemKey = "SomeSystem";
            var query = new MockQuery(systemKey, key);
            Sut.Save(query);

            //Act
            var result = Sut.Load<MockQuery>(systemKey, typeof(MockQuery).FullName, key);

            //Assert
            result.ShouldBeEquivalentTo(query);
        }
    }
}
