using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Helpers;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class AtmosphereGenerator
    {
        public static short Generate(string orbitType, int size)
        {
            int dieRoll = DieRoll.Roll2D6() - 7 + size;

            if (orbitType.Equals(OrbitTypes.Inner))
            {
                dieRoll -= 2;
            }

            if (orbitType.Equals(OrbitTypes.Outer))
            {
                dieRoll -= 4;
            }

            if (size == 0)
            {
                dieRoll = 0;
            }

            if (dieRoll < 1)
            {
                dieRoll = 0;
            }

            return (short)dieRoll;
        }
    }
}
