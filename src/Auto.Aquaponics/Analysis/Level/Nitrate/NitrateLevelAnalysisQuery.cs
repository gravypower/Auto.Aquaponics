﻿namespace Auto.Aquaponics.Analysis.Level.Nitrate
{
    public class NitrateLevelAnalysisQuery : LevelAnalysisQuery<NitrateLevelAnalysis>
    {
        public NitrateLevelAnalysisQuery()
        {
        }

        public NitrateLevelAnalysisQuery(double value) : base(value)
        {
        }

        public override LevelAnalysisQuery<NitrateLevelAnalysis> Clone()
        {
            return new NitrateLevelAnalysisQuery(Value);
        }
    }
}
