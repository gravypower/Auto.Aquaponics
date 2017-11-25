﻿namespace Auto.Aquaponics.Analysis.Levels.Ph
{
    public interface IAnalysePhMagicStrings : ILevelsMagicStrings
    {
        string LowPhArgumentOutOfRangeExceptionMessage { get; }
        string HightPhArgumentOutOfRangeExceptionMessage { get; }
        string OrganismPhTolerancesNotDefinedExceptionMessage { get; }
    }
}
