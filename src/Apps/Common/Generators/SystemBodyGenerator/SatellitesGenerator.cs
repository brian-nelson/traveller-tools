using System.Collections.Generic;
using TravellerUtils.Libraries.Common.Interfaces;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class SatellitesGenerator
    {
        public static List<ISystemBody> Generate(int worldSize, double orbitalDistance, 
            string occupiedType, int orbitNumber, string orbitType, string stellarClassification, 
            double planetDiameter, string planetDensity, double luminosity, int habitableZone)
        {
            List<ISystemBody> satellites = new List<ISystemBody>();

            int numberOfSatellites = NumberOfSatellitesGenerator.Generate(occupiedType, worldSize);

            for (int i = 0; i < numberOfSatellites; i++)
            {
                var satellite = SatelliteGenerator.Generate(worldSize, orbitalDistance, 
                    occupiedType, orbitNumber, orbitType, stellarClassification, 
                    planetDiameter, planetDensity, luminosity, habitableZone);

                satellites.Add(satellite);
            }
            
            return satellites;
        }
    }
}
