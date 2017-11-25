
namespace Auto.Aquaponics.Analysis.Levels
{
    public abstract class AnalyseMagicStrings: ILevelsMagicStrings
    {
        public string OrganismNotDefined => "Organism not defined";
        public string OrganismTolerancesNotDefined => "Organism tolerances not defined";
        public abstract string LevelsKey { get; }
    }
}
