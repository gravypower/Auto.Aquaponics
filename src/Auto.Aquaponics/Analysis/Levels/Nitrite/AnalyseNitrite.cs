﻿using ServiceStack;

namespace Auto.Aquaponics.Analysis.Levels.Nitrite
{
    [Api("Returns Analysis of Nitrite levels for an Organism")]
    [Route("/organisms/{OrganismId}/Tolerances/Nitrite/{Value}", "GET")]
    public class AnalyseNitrite : AnalyseQuery<NitriteAnalysis, NitriteTolerance>
    {
    }
}
