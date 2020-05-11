using TravellerUtils.Libraries.Common.Constants;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class PlanetGravityGenerator
    {
        public static double Generate(double distance, double mass)
        {
            double gravityAtSurface = (SystemBodyConstants.GravitationalConstant * mass) / (distance * distance);
            return gravityAtSurface;
        }
    }
}
