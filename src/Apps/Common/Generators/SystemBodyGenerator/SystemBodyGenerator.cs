using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Interfaces;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class SystemBodyGenerator
    {
        public static IOrbitingBody Generate(short orbitNumber, Distance orbitalDistance, string occupiedType, 
            string orbitType, IStar parentStar, StellarSystem stellarSystem)
        {
            switch (occupiedType)
            {
                case OccupiedTypes.GasGiant:
                    return GasGiantGenerator.Generate(orbitalDistance, orbitNumber, occupiedType, orbitType, parentStar, stellarSystem.CombinedLuminosity);
                case OccupiedTypes.CapturedPlanet:
                case OccupiedTypes.World:
                    return WorldGenerator.Generate( orbitalDistance, orbitNumber, occupiedType, orbitType, parentStar, stellarSystem.CombinedLuminosity);
                case OccupiedTypes.Planetoid:
                    break;
                case OccupiedTypes.Star:
                    //Do nothing for this.  Should already be done
                    break;
            }

            return null;
        }

    }
}
