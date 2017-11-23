using Auto.Aquaponics.Query;
using System;
namespace Auto.Aquaponics.Organisms
{
    public class GetOrganism : IQuery<Organism>
    {
        public Guid Id { get; set; }
    }
}
