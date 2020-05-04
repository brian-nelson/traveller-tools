using System;
using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Interfaces;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class SystemBodyGenerator
    {
        public static ISystemBody Generate(short orbitNumber, double orbitalDistance, string occupiedType, 
            string orbitType, string stellarClassification, double stellarMass, double luminosity, 
            int habitableZone)
        {
            double x = Math.Pow(orbitalDistance, 3) / stellarMass;
            double orbitPeriod = Math.Sqrt(x);

            switch (occupiedType)
            {
                case OccupiedTypes.GasGiant:
                    return GasGiantGenerator.Generate(orbitPeriod, orbitalDistance, orbitNumber, occupiedType, orbitType, 
                        stellarClassification, stellarMass, luminosity, habitableZone);
                case OccupiedTypes.CapturedPlanet:
                case OccupiedTypes.World:
                    return WorldGenerator.Generate(orbitPeriod, orbitalDistance, orbitNumber, occupiedType, orbitType,
                        stellarClassification, stellarMass, luminosity, habitableZone);
                case OccupiedTypes.Planetoid:
                    break;
                case OccupiedTypes.Star:
                    break;
            }

            return null;
        }

    }
}
