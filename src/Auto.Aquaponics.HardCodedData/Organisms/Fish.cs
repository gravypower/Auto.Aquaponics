using Auto.Aquaponics.Organisms;
using System;

namespace Auto.Aquaponics.HardCodedData.Organisms
{
    public abstract class Fish : Organism
    {
        protected Fish(string name):base(Guid.NewGuid(), name)
        {
            AddTolerances(new Tolerance("Salinity", Scale.Ppm, 0, 0.02, 0, 0));
            AddTolerances(new Tolerance("pH", Scale.Ph, 6, 10, 6.5, 9));
            AddTolerances(new Tolerance("Nitrite", Scale.Ppm, 0, 40, 0, 20));
            AddTolerances(new Tolerance("Nitrate", Scale.Ppm, 0, 40, 0, 20));
            AddTolerances(new Tolerance("Ammonia", Scale.Ppm, 0, 0.02, 0, 0));
        }
    }
}
