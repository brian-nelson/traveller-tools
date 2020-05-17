using TravellerUtils.Libraries.Common.Enums;
using TravellerUtils.Libraries.Common.Interfaces;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class AsteroidBeltGenerator
    {
        public static IOrbitingBody Generate(
            Distance orbitalDistance,
            short orbitNumber,
            string occupiedType,
            string orbitType,
            IStar parentStar,
            double combinedLuminosity)
        {
            AsteroidBelt belt = new AsteroidBelt
            {
                Size = 0,
                OrbitNumber = orbitNumber,
                OrbitalDistance = orbitalDistance,
                Diameter = new Distance(0, DistanceUnits.AstronomicalUnit),
                Mass = new Mass()
            };


            return belt;
        }
    }
}
