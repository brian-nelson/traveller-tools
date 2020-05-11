using System;
using System.Collections.Generic;
using System.Text;
using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Helpers;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class OrbitTypeGenerator
    {
        public static string Generate(Distance orbitalDistance, double luminosity, double companionLuminosity)
        {
            var L = luminosity;
            var O = SystemConstants.HabitNum / Math.Sqrt(orbitalDistance.ToAstronomicalUnits().Value);
            var LO = L * O;

            LO = LO + companionLuminosity;

            if (LO > 8 * SystemConstants.HabitHigh)
            {
                return OrbitTypes.Unavailable;
            }

            if (LO > SystemConstants.HabitHigh)
            {
                return OrbitTypes.Inner;
            }

            if (LO < SystemConstants.HabitLow)
            {
                return OrbitTypes.Outer;
            }

            return OrbitTypes.Habitable;
        }
    }
}
