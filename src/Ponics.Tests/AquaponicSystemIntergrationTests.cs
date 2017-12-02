using Ponics.Kernel;
using NUnit.Framework;
using System;
using Ponics.Analysis.Levels.Ph;
using Ponics.AquaponicSystems;
using Ponics.Components;
using Ponics.Organisms;

namespace Ponics.Tests
{
    [TestFixture]
    public class AquaponicSystemIntergrationTests
    {
        [Test]
        public void IntergrationTest()
        {
            var system = new AquaponicSystem {Id = Guid.NewGuid(), Name = "IntergrationTest"};
            ;

            var fishTank = new Component {Name = "fishTank"};

            var silverPerch = new Organism {Id = Guid.NewGuid(), Name = "silverPerch"};
            var silverPerchTolerances = new PhTolerance(6, 10, 6.5, 9);
            silverPerch.Tolerances.Add(silverPerchTolerances);

            var catFish = new Organism {Id = Guid.NewGuid(), Name = "catFish"};

            fishTank.AddOrganisms(silverPerch.Id, catFish.Id);

            var growBed = new Component {Name = "growBed"};
            var sumpTank = new Component {Name = "sumpTank"};

            system.AddComponents(fishTank, growBed, sumpTank);

        }
    }
}