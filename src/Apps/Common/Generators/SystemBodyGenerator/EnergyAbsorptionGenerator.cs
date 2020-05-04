using TravellerUtils.Libraries.Common.Constants;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class EnergyAbsorptionGenerator
    {
        public static double Generate(string orbitType, short hydro, short atmosphereCode)
        {
            double output;

            if (orbitType == OrbitTypes.Habitable)
            {
                output = PlanetTables.EnergyAbsorbHZ[hydro, atmosphereCode];
            }
            else
            {
                output = PlanetTables.EnergyAbsorbNHZ[hydro, atmosphereCode];
            }

            return output;
        }
    }
}
