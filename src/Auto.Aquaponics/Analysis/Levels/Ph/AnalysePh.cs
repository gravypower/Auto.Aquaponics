using ServiceStack;

namespace Auto.Aquaponics.Analysis.Levels.Ph
{
    [Api("Returns Analysis of pH level for an Organism")]
    [Route("/organisms/{OrganismId}/Tolerances/Ph/{Value}", "GET")]
    public class AnalysePh : AnalyseQuery<PhAnalysis, PhTolerance>
    {
    }
}
