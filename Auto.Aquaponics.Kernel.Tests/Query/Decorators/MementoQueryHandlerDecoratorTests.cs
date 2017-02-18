using Auto.Aquaponics.Kernel.Persistence;
using Auto.Aquaponics.Kernel.Query.Decorators;
using NSubstitute;
using NUnit.Framework;

namespace Auto.Aquaponics.Kernel.Tests.Query.Decorators
{
    [TestFixture]
    public class MementoQueryHandlerDecoratorTests
    {
        protected MementoQueryHandlerDecorator<MockQuery, MockQueryResult> Sut;
        private MockQueryHandler _mockQueryHandler;
        private QueryMemento _queryMemento;

        [SetUp]
        public void SetUp()
        {
            _mockQueryHandler = new MockQueryHandler();
            _queryMemento = Substitute.For<QueryMemento>();
            Sut = new MementoQueryHandlerDecorator<MockQuery, MockQueryResult>(_queryMemento, _mockQueryHandler);
        }

        [Test]
        public void GivenQueryHandlerIsDecoratoredWhenQueryHandeledThenQueryPassedToMemento()
        {
            var mockQuery = new MockQuery();
            Sut.Handle(mockQuery);
            _queryMemento.Received().Save(mockQuery);
        }
    }
}
