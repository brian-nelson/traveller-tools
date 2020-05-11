using System;
using System.Collections.Generic;
using System.Text;
using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Helpers;
using TravellerUtils.Libraries.Common.Interfaces;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class OrbitFactorGenerator
    {
        public static double Generate(IOrbitingBody planet)
        {
            return SystemConstants.HabitNum / Math.Sqrt(planet.OrbitalDistance.ToAstronomicalUnits().Value);
        }
    }
}
