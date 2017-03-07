
namespace Auto.Aquaponics.Query.LevelAnalysis
{
    public abstract class LevelQueryHandlerMagicStrings: ILevelQueryHandlerMagicStrings
    {
        public string OrganismNotDefinedExceptionMessage => "Organism not defined";
        public string OrganismTolerancesNotDefinedExceptionMessage => "Organism tolerances not defined";
        public abstract string LevelKey { get; }
    }
}
