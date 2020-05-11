﻿using System.Collections.Generic;
using TravellerUtils.Libraries.Common.Interfaces;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class SatellitesGenerator
    {
        public static List<IOrbitingBody> Generate(IStar parentStar, IStellarOrbitingBody parentBody, double combinedLuminosity)
        {
            List<IOrbitingBody> satellites = new List<IOrbitingBody>();

            int numberOfSatellites = NumberOfSatellitesGenerator.Generate(parentBody.OrbitOccupiedType, parentBody.Size);

            for (int i = 0; i < numberOfSatellites; i++)
            {
                var satellite = SatelliteGenerator.Generate(parentStar, parentBody);

                satellites.Add(satellite);
            }
            
            return satellites;
        }
    }
}
