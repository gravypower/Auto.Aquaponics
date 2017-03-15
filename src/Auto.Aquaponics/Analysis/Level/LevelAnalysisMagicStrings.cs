
namespace Auto.Aquaponics.Analysis.Level
{
    public abstract class LevelAnalysisMagicStrings: ILevelMagicStrings
    {
        public string OrganismNotDefined => "Organism not defined";
        public string OrganismTolerancesNotDefined => "Organism tolerances not defined";
        public abstract string LevelKey { get; }
    }
}
