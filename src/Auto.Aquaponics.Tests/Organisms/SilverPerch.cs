using System.Collections.Generic;
using Auto.Aquaponics.Kernel;
using Auto.Aquaponics.Organisms;

namespace Auto.Aquaponics.Tests.Organisms
{
    public class SilverPerch : Organism
    {
        public SilverPerch() : base("Silver Perch")
        {
            AddTolerances(new Tolerance("Salinity", Scale.Ppm, 0.02, 0, 0, 0));
            AddTolerances(new Tolerance("pH", Scale.Ph, 10, 6, 9, 6.5));
            AddTolerances(new Tolerance("Nitrite", Scale.Ppm, 40, 0, 20, 0));
            AddTolerances(new Tolerance("Nitrate", Scale.Ppm, 40, 0, 20, 0));
            AddTolerances(new Tolerance("Ammonia", Scale.Ppm, 0.02, 0, 0, 0));
        }
    }
}
