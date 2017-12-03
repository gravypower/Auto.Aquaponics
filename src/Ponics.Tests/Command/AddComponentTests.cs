using NUnit.Framework;
using Ponics.Components;

namespace Ponics.Tests.Command
{
    [TestFixture]
    public class AddComponentTests
    {
        public AddComponentCommandHandler Sut;

        [SetUp]
        public void SetUp()
        {
            Sut = new AddComponentCommandHandler();
        }
    }
}
