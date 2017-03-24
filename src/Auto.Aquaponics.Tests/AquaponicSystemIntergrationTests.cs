using Auto.Aquaponics.AquaponicSystems;
using Auto.Aquaponics.Components;
using Auto.Aquaponics.Kernel;
using Auto.Aquaponics.Organisms;
using NUnit.Framework;

namespace Auto.Aquaponics.Tests
{
    [TestFixture]
    public class AquaponicSystemIntergrationTests
    {
        [Test]
        public void IntergrationTest()
        {
            var system = new AquaponicSystem("SomeName");

            var fishTank = new Component("fishTank");

            var silverPerch = new Organism("silverPerch");
            var silverPerchTolerances = new Tolerance("Ph", Scale.Ph, 6, 10, 6.5, 9);
            silverPerch.AddTolerances(silverPerchTolerances);

            var catFish = new Organism("catFish");

            fishTank.AddOrganisms(silverPerch, catFish);

            var growBed = new Component("growBed");
            var sumpTank = new Component("sumpTank");

            system.AddComponents(fishTank, growBed, sumpTank);

        }
    }
}
