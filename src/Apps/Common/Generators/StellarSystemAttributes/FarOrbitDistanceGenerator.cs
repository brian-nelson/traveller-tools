using TravellerUtils.Libraries.Common.Enums;
using TravellerUtils.Libraries.Common.Helpers;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Generators.StellarSystemAttributes
{
    public static class FarOrbitDistanceGenerator
    {
        public static Distance Generate()
        {
            Distance min = new Distance()
            {
                Units = DistanceUnits.LightYear,
                Value = 0.5
            };

            Distance max = new Distance()
            {
                Units = DistanceUnits.LightYear,
                Value = 1.5
            };

            return PerturbHelper.Change(min, max);
        }
    }
}
