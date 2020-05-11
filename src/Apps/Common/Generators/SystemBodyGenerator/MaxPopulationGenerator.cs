using TravellerUtils.Libraries.Common.Constants;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class MaxPopulationGenerator
    {
        public static short Generate(int orbitNumber, string orbitType,
            int bodySize, int atmosphere, int hydrographics, int habitableZone)
        {
            int maxPop = 10;
            if (bodySize < 4)
            {
                maxPop -= 1;
            }

            if (bodySize < 7)
            {
                maxPop -= 1;
            }

            if (atmosphere == 5)
            {
                maxPop -= 1;
            }

            if (atmosphere == 7)
            {
                maxPop -= 1;
            }

            if (atmosphere == 9)
            {
                maxPop -= 1;
            }

            if (atmosphere == 4)
            {
                maxPop -= 2;
            }

            if (atmosphere > 12)
            {
                maxPop -= 3;
            }

            if (hydrographics < 3)
            {
                maxPop -= 1;
            }

            if (hydrographics == 10)
            {
                maxPop -= 1;
            }

            if (hydrographics == 0)
            {
                maxPop -= 2;
            }

            if (atmosphere < 4)
            {
                maxPop = 0;
            }

            if (atmosphere > 9)
            {
                maxPop = 0;
            }

            if (atmosphere == 10)
            {
                maxPop = 0;
            }

            if (atmosphere == 11)
            {
                maxPop = 0;
            }

            if (atmosphere == 12)
            {
                maxPop = 0;
            }

            if (orbitType != OrbitTypes.Habitable)
            {
                if (orbitNumber > habitableZone)
                {
                    maxPop = maxPop - (orbitNumber - habitableZone) * 2;
                }
                else
                {
                    maxPop = maxPop - (habitableZone - orbitNumber) * 2;
                }
            }

            if (maxPop < 0)
            {
                maxPop = 0;
            }

            return (short)maxPop;
        }
    }
}
