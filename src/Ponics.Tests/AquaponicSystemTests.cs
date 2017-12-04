using System;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Ponics.AquaponicSystems;
using Ponics.Components;

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

