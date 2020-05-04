using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Helpers;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class GasGiantGenerator
    {
        public static GasGiant Generate(double orbitPeriod, double orbitalDistance, int orbitNumber, string occupiedType, 
            string orbitType, string stellarClassification, double stellarMass, double luminosity, int habitableZone)
        {
            int size;

            var output = new GasGiant { OrbitalDistance = orbitalDistance };

            if (DieRoll.Roll1D6() < 3)
            {
                //Small
                size = -1;
                output.Description = "Small";
                output.Diameter = PlanetSizeGenerator.Generate(occupiedType, size);
            }
            else
            {
                //Large
                size = -2;
                output.Description = "Large";
                output.Diameter = PlanetSizeGenerator.Generate(occupiedType, size);
            }

            var satellites = SatellitesGenerator.Generate(
                size, orbitalDistance, occupiedType, orbitNumber, orbitType, stellarClassification,
                output.Diameter, PlanetDensities.Low, luminosity, habitableZone);

            output.OrbitingBodies.AddRange(satellites);

            return output;
        }
    }
}
