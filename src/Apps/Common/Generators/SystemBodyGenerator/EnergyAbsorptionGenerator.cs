using TravellerUtils.Libraries.Common.Constants;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class EnergyAbsorptionGenerator
    {
        public static double Generate(string orbitType, short hydrographics, short atmosphereCode)
        {
            double output;

            if (orbitType == OrbitTypes.Habitable)
            {
                output = PlanetTables.EnergyAbsorbHZ[hydrographics, atmosphereCode];
            }
            else
            {
                output = PlanetTables.EnergyAbsorbNHZ[hydrographics, atmosphereCode];
            }

            return output;
        }
    }
}
