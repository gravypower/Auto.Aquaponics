
namespace Ponics.Analysis.Levels.MagicStrings
{
    public abstract class AnalyseMagicStrings: ILevelsMagicStrings
    {
        public string OrganismNotDefined => "Organism not defined";
        public string OrganismTolerancesNotDefined => "Organism tolerances not defined";
        public abstract string LevelName { get; }
    }
}
