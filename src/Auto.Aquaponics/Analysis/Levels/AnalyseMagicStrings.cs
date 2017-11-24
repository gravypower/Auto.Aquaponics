
namespace Auto.Aquaponics.Analysis.Levels
{
    public abstract class AnalyseMagicStrings: ILevelMagicStrings
    {
        public string OrganismNotDefined => "Organism not defined";
        public string OrganismTolerancesNotDefined => "Organism tolerances not defined";
        public abstract string LevelKey { get; }
    }
}
