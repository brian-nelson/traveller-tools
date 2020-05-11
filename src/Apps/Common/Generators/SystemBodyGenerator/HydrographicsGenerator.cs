using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Helpers;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class HydrographicsGenerator
    {
        public static short Generate(string orbitType, int satelliteSize, int atmosphere)
        {
            int dieRoll = DieRoll.Roll2D6() - 2;

            if (orbitType.Equals(OrbitTypes.Inner))
            {
                dieRoll = 0;
            }

            if (orbitType.Equals(OrbitTypes.Outer))
            {
                dieRoll -= 2;
            }

            if (atmosphere < 2)
            {
                dieRoll -= 1;
            }

            if (atmosphere < 4)
            {
                dieRoll -= 1;
            }

            if (satelliteSize == 0)
            {
                dieRoll -= 4;
            }

            if (satelliteSize == 1)
            {
                dieRoll -= 3;
            }

            if (satelliteSize == 2)
            {
                dieRoll -= 1;
            }

            if (dieRoll < 1)
            {
                dieRoll = 0;
            }

            if (dieRoll > 10)
            {
                dieRoll = 10;
            }

            return (short)dieRoll;
        }
    }
}
