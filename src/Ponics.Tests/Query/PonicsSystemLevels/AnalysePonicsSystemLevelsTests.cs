using NUnit.Framework;
using Ponics.Analysis.PonicsSystemLevels;

namespace Ponics.Tests.Query.PonicsSystemLevels
{
    public class AnalysePonicsSystemLevelsTests
    {
        public AnalysePonicsSystemLevelsHandler Sut;

        [SetUp]
        public void SetUp()
        {
            Sut = new AnalysePonicsSystemLevelsHandler();
        }
    }
}
