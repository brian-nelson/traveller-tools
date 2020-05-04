using System;
using TravellerUtils.Libraries.Common.Constants;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class PlanetGravityGenerator
    {
        public static double Generate(double diameter, string density)
        {
            double r = diameter / 2;
            double v = (4 * Math.PI) / 3 * Math.Pow(r, 3);
            v = v / SystemBodyConstants.EarthGravity;

            switch (density)
            {
                case PlanetDensities.Low:
                    return v * 0.55;
                case PlanetDensities.Average:
                    return v;
                case PlanetDensities.High:
                    return v * 1.55;
            }

            return v;
        }
    }
}
