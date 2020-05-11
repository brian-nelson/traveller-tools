using System;
using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Enums;
using TravellerUtils.Libraries.Common.Helpers;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    /// <summary>
    /// Returns earth relative masses - #.# of Earths
    /// </summary>
    public static class PlanetMassGenerator
    {
        public static Mass Generate(Distance bodyDiameter, string bodyDensity)
        {
            Distance radius = bodyDiameter / 2;
            double volume = (4 * Math.PI) / 3 * Math.Pow(radius.ToMeters().Value, 3);

            double density = 0;

            switch (bodyDensity)
            {
                case PlanetDensities.Low:
                    density = PerturbHelper.Change(650, 1500);  // kg/m^3
                    break;
                case PlanetDensities.Average:
                    density = PerturbHelper.Change(1500, 3000);
                    break;
                case PlanetDensities.High:
                    density = PerturbHelper.Change(3000, 6000);
                    break;
            }

            double kgs = volume * density;

            Mass mass = new Mass
            {
                Value = kgs, 
                Units = MassUnits.Kilogram
            };

            return mass;
        }
    }
}
