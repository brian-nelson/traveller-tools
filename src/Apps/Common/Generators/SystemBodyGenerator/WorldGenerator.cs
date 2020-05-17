using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Interfaces;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class WorldGenerator
    {
        public static IOrbitingBody Generate(
            Distance orbitalDistance, 
            short orbitNumber, 
            string occupiedType, 
            string orbitType, 
            IStar parentStar,
            double combinedLuminosity)
        {
            var p = new Planet();

            p.Size = SystemBodySizeGenerator.Generate(orbitNumber, parentStar.Classification);
            p.Diameter = PlanetDiameterGenerator.Generate(occupiedType, p.Size);
            p.Density = DensityGenerator.Generate(orbitType);
            p.Mass = PlanetMassGenerator.Generate(p.Diameter, p.Density);

            p.OrbitNumber = orbitNumber;
            p.OrbitalDistance = orbitalDistance;
            p.OrbitalPeriod = OrbitalPeriodGenerator.Generate(parentStar, p);
            p.OrbitEccentricity = OrbitalEccentricityGenerator.Generate();
            p.OrbitFactor = OrbitFactorGenerator.Generate(p);
            p.RotationPeriod = RotationPeriodGenerator.Generate(parentStar.Mass, p.OrbitalDistance);
            p.AxialTilt = AxialTiltGenerator.Generate();
            p.AxialTiltEffect = TiltEffectGenerator.Generate(p.AxialTilt);

            p.Atmosphere = AtmosphereGenerator.Generate(orbitType, p.Size);
            p.AtmosphereCode = AtmosphereCodeGenerator.Generate(p.Atmosphere); 
            p.Hydrographics = HydrographicsGenerator.Generate(orbitType, p.Atmosphere, p.Size);
            p.MaxPopulation = MaxPopulationGenerator.Generate(orbitNumber, orbitType, p.Size, p.Atmosphere, p.Hydrographics, parentStar.HabitableZone);
            p.EnergyAbsorptionFactor = EnergyAbsorptionGenerator.Generate(orbitType, p.Hydrographics, p.AtmosphereCode);
            p.GreenhouseFactor = GreenhouseTables.GreenHouse[p.Atmosphere];

            if (SystemConstants.UseGaiaFactor
                && p.MaxPopulation > 5)
            {
                p.EnergyAbsorptionFactor = GaiaFactorGenerator.Generate(combinedLuminosity, p.OrbitFactor, p.GreenhouseFactor, p.EnergyAbsorptionFactor);
            }

            p.MeanTemperature = MeanTemperatureGenerator.Generate(combinedLuminosity, p.OrbitFactor,
                p.EnergyAbsorptionFactor, p.GreenhouseFactor);

            p.Seasons = SeasonsGenerator.Generate(p.Size, p.AxialTilt, p.AxialTiltEffect, p.OrbitFactor,
                p.MeanTemperature, combinedLuminosity, p.OrbitalDistance, p.RotationPeriod, p.Atmosphere);
            
            SatellitesGenerator.Generate(parentStar, p, combinedLuminosity);

            return p;
        }
    }
}
