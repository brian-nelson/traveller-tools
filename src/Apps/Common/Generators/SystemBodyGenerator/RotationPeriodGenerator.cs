using TravellerUtils.Libraries.Common.Helpers;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class RotationPeriodGenerator
    {
        public static double Generate(Mass parentMass, Distance orbitalDistance)
        {
            return (4 * (DieRoll.Roll2D6() - 2)) + 5 + (parentMass.ToStellarMasses().Value / orbitalDistance.ToAstronomicalUnits().Value);
        }
    }
}
