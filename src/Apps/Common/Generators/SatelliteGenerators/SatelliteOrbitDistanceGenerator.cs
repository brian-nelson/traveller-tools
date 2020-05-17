using TravellerUtils.Libraries.Common.Interfaces;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Generators.SatelliteGenerators
{
    public static class SatelliteOrbitDistanceGenerator
    {
        public static Distance Generate(ISystemBody parentBody)
        {
            var value= (parentBody.Diameter / 2) * SatelliteOrbitGenerator.Generate();
            return value;
        }
    }
}
