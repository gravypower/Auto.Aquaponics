using System;
using System.Collections.Generic;
using Auto.Aquaponics.Tolerances;

namespace Auto.Aquaponics.Organisms
{
    public class Organism
    {
        public string Name { get; set; }
        public Guid Id { get; set; }

        public IList<Tolerance> Tolerances { get; set; }


        public Organism()
        {
            Tolerances = new List<Tolerance>();
        }
    }
}
