using System;
using NUnit.Framework;
using Ponics.Aquaponics;

namespace Ponics.Tests
{
    [TestFixture]
    public class AquaponicSystemTests
    {
        public AquaponicSystem Sut;

        [SetUp]
        public void SetUp()
        {
            Sut = new AquaponicSystem
            {
                Id = Guid.NewGuid(),
                Name = "AquaponicSystem"
            };
        }

       
    }
}

