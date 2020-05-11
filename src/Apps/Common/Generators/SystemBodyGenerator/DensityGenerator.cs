using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Helpers;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public class DensityGenerator
    {
        public static string Generate(string orbitType)
        {
            int dieRoll = DieRoll.Roll1D6();

            if (orbitType.Equals(OrbitTypes.Outer))
            {
                dieRoll -= 2;
            }

            if (dieRoll < 2)
            {
                return PlanetDensities.Low;
            }

            if (dieRoll > 4)
            {
                return PlanetDensities.High;
            }

            return PlanetDensities.Average;
        }
    }
}
