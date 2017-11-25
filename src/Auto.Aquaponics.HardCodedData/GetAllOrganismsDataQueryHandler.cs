﻿using Auto.Aquaponics.HardCodedData.Organisms;
using Auto.Aquaponics.Organisms;
using System.Collections.Generic;
using Auto.Aquaponics.Kernel.Data;
using Auto.Aquaponics.Queries;

namespace Auto.Aquaponics.HardCodedData
{
    public class GetAllOrganismsDataQueryHandler: 
        IDataQueryHandler<GetAllOrganisms, IList<Organism>>,
        IQueryHandler<GetAllOrganisms, IList<Organism>>
    {
        public IList<Organism> Handle(GetAllOrganisms query)
        {
            return new List<Organism>
            {
                new SilverPerch(),
                new GoldFish(),
                new Nitrosomonas(),
                new Nitrospira(),
                new Worm()
            };
            
        }
    }
}
