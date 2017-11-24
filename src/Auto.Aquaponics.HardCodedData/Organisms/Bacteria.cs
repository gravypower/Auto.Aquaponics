using Auto.Aquaponics.Organisms;
using System;

namespace Auto.Aquaponics.HardCodedData.Organisms
{
    public class Bacteria:Organism
    {
        protected Bacteria(Guid id, string name):base(id, name)
        {
            AddTolerances(new Tolerance("Salinity", Scale.Ppm, 0, 0.02, 0, 0));
            AddTolerances(new Tolerance("pH", Scale.Ph, 6, 8.5, 6, 8.5));
            AddTolerances(new Tolerance("Nitrite", Scale.Ppm, 0, 40, 0, 20));
            AddTolerances(new Tolerance("Nitrate", Scale.Ppm, 0, 40, 0, 20));
            AddTolerances(new Tolerance("Ammonia", Scale.Ppm, 0, 0.02, 0, 0));
        }
    }
}
