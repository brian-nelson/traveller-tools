using System;
using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Helpers;
using TravellerUtils.Libraries.Common.Interfaces;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class GasGiantGenerator
    {
        public static GasGiant Generate(Distance orbitalDistance, short orbitNumber, string occupiedType, 
            string orbitType, IStar parentStar, double combinedLuminosity)
        {
            int size;

            var gasGiant = new GasGiant 
            { 
                OrbitalDistance = orbitalDistance, 
                Density = PlanetDensities.Low
            };

            if (DieRoll.Roll1D6() < 3)
            {
                //Small
                size = -1;
                gasGiant.Description = "Small";
            }
            else
            {
                //Large
                size = -2;
                gasGiant.Description = "Large";
            }

            gasGiant.Diameter = PlanetDiameterGenerator.Generate(occupiedType, size);
            gasGiant.Mass = PlanetMassGenerator.Generate(gasGiant.Diameter, gasGiant.Density);
            gasGiant.OrbitNumber = orbitNumber;
            gasGiant.OrbitalDistance = orbitalDistance;
            gasGiant.OrbitEccentricity = OrbitalEccentricityGenerator.Generate(); 
            
            gasGiant.OrbitalPeriod = OrbitalPeriodGenerator.Generate(parentStar, gasGiant);
            
            gasGiant.RotationPeriod = RotationPeriodGenerator.Generate(parentStar.Mass, gasGiant.OrbitalDistance);
            gasGiant.AxialTilt = AxialTiltGenerator.Generate();
            gasGiant.AxialTiltEffect = TiltEffectGenerator.Generate(gasGiant.AxialTilt);
            
            var satellites = SatellitesGenerator.Generate(parentStar, gasGiant, combinedLuminosity);

            gasGiant.OrbitingBodies.AddRange(satellites);

            return gasGiant;
        }
    }
}
