using Auto.Aquaponics.Components;
using Auto.Aquaponics.Kernel;
using Auto.Aquaponics.Kernel.GraphTheory.Graphs;
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
            var graph = new DirectedAcyclicGraph<Component>();
            var system = new AquaponicSystem(graph);

            var fishTank = new Component();

            var silverPerch = new Organism("silverPerch");
            var silverPerchTolerances = new Tolerance("Ph", Scale.Ph, 10, 6, 9, 6.5);
            silverPerch.AddTolerances(silverPerchTolerances);

            var catFish = new Organism("catFish");

            fishTank.AddOrganisms(silverPerch, catFish);

            var growBed = new Component();
            var sumpTank = new Component();

            system.AddComponents(fishTank, growBed, sumpTank);

        }
    }
}
