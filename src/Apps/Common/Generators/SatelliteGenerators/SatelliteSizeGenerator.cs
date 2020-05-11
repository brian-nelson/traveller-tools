using System;
using System.Collections.Generic;
using System.Text;
using TravellerUtils.Libraries.Common.Helpers;

namespace TravellerUtils.Libraries.Common.Generators.SatelliteGenerators
{
    public static class SatelliteSizeGenerator
    {
        public static short Generate(int worldSize)
        {
            int dieRoll;

            if (worldSize == -1) /* Small Gas Giant */
            {
                dieRoll = DieRoll.Roll2D6() - 6;  //Max 6
            }
            else if (worldSize == -2) /* Large Gas Giant */
            {
                dieRoll = DieRoll.Roll2D6() - 4;  //Max 8
            }
            else
            {
                dieRoll = DieRoll.Roll1D6() - 3;  //Max 3
            }

            if (dieRoll == 0)
            {
                //Ring
                return 0;
            }

            if (dieRoll >= worldSize
                && worldSize >= 0)
            {
                dieRoll = worldSize - 1;
            }

            if (dieRoll < 1)
            {
                dieRoll = 0;
            }

            return (short)dieRoll;
        }
    }
}
