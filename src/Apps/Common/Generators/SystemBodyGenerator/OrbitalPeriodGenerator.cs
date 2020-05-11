using System;
using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Helpers;
using TravellerUtils.Libraries.Common.Interfaces;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class OrbitalPeriodGenerator
    {
        public static double Generate(ISystemBody parent, IOrbitingBody child)
        {
            Distance childOrbitInMeters = child.OrbitalDistance.ToMeters();
            Mass combinedMass = (parent.Mass + child.Mass);

            double numerator = 4 * Math.Pow(Math.PI, 2) * Math.Pow(childOrbitInMeters.Value, 3);
            double denominator = SystemBodyConstants.GravitationalConstant * combinedMass.ToKilograms().Value;

            double t = Math.Sqrt(numerator / denominator);

            return t;
        }
    }
}
