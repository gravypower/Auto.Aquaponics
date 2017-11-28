﻿namespace Auto.Aquaponics.Analysis.Levels.Salinity
{
    public class SalinityTolerance : Tolerance
    {
        public SalinityTolerance(double lower, double upper, double desiredLower, double desiredUpper) : base(lower, upper, desiredLower, desiredUpper)
        {
        }

        public override Scale Scale => Scale.Ppm;
    }
}