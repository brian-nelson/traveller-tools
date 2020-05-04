using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Helpers;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class NumberOfSatellitesGenerator
    {
        public static int Generate(string occupiedType, int size)
        {
            int numberOfSatellites = 0;
            
            if (occupiedType.Equals(OccupiedTypes.GasGiant))
            {
                if (size == -1)
                {
                    //Small
                    numberOfSatellites = DieRoll.Roll2D6() - 4;
                }
                else if (size == -2)
                {
                    //Large
                    numberOfSatellites = DieRoll.Roll2D6();
                }
            }
            else if (size == 0)
            {
                numberOfSatellites = 0;
            }
            else if (occupiedType.Equals(OccupiedTypes.CapturedPlanet))
            {
                numberOfSatellites = 0;
            }
            else
            {
                numberOfSatellites = DieRoll.Roll1D6() - 3;
            }

            if (numberOfSatellites < 1)
            {
                numberOfSatellites = 0;
            }

            return numberOfSatellites;
        }
    }
}
