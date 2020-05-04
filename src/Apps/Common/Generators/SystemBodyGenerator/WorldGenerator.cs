using System;
using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Helpers;
using TravellerUtils.Libraries.Common.Interfaces;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class WorldGenerator
    {
        public static ISystemBody Generate(double orbitPeriod, double orbitalDistance, short orbitNumber, string occupiedType,
            string orbitType, string stellarClassification, double stellarMass, double luminosity, int habitableZone)
        {
            var p = new Planet();

            p.Size = GenerateSize(orbitNumber, stellarClassification);
            p.Density = GenerateDensity(orbitType);
            p.Atmosphere = GenerateAtmosphere(orbitType, p.Size);
            p.Hydrographics = GenerateHydrographic(orbitType, p.Atmosphere, p.Size);
            p.MaxPopulation = GeneratePopulation(orbitNumber, p.Size, p.Atmosphere, p.Hydrographics, orbitType, habitableZone);
            p.RotationPeriod = (4 * (DieRoll.Roll2D6() - 2)) + 5 + (stellarMass / orbitalDistance);
            p.OrbitFactor = SystemConstants.HabitNum / Math.Sqrt(orbitalDistance);
            p.AtmosphereCode = AtmosphereCodeGenerator.Generate(p.Atmosphere);
            p.EnergyAbsorptionFactor = GenerateEnergyAbsorption(orbitType, p.Hydrographics, p.AtmosphereCode);
            p.GreenhouseFactor = GreenhouseTables.GreenHouse[p.Atmosphere];

            if (SystemConstants.UseGaiaFactor
                && p.MaxPopulation > 5)
            {
                p.EnergyAbsorptionFactor = GaiaFactorGenerator.Generate(luminosity, p.OrbitFactor, p.GreenhouseFactor, p.EnergyAbsorptionFactor);
            }

            p.MeanTemperature = (luminosity * p.OrbitFactor * p.EnergyAbsorptionFactor * p.GreenhouseFactor) - 273;
            p.AxialTilt = AxialTiltGenerator.Generate();
            p.AxialTiltEffect = GetTiltEffect(p.AxialTilt);
            p.OrbitEccentricity = OrbitalEccentricityGenerator.Generate();
            p.Seasons = SeasonsGenerator.Generate(p.Size, p.AxialTilt, p.AxialTiltEffect, p.OrbitFactor,
                p.MeanTemperature, luminosity, p.OrbitalDistance, p.RotationPeriod, p.Atmosphere);
            p.PlanetDiameter = PlanetSizeGenerator.Generate(occupiedType, p.Size);
            
            var numberOfSatellites = NumberOfSatellitesGenerator.Generate(occupiedType, p.Size);
            var satellites = SatellitesGenerator.Generate(p.Size, p.OrbitalDistance, occupiedType,
                orbitNumber, orbitType, stellarClassification, p.PlanetDiameter, p.Density, luminosity, habitableZone);

            p.OrbitingBodies.AddRange(satellites);

            return p;
        }

        private static short GetTiltEffect(double axialTilt)
        {
            /* k is tilt effect column */
            if (axialTilt <= 0.0)
            {
                return 0;
            }

            if (axialTilt < 6.0)
            {
                return 1;
            }

            if (axialTilt < 11.0)
            {
                return 2;
            }

            if (axialTilt < 16.0)
            {
                return 3;
            }

            if (axialTilt < 21.0)
            {
                return 4;
            }

            if (axialTilt < 26.0)
            {
                return 5;
            }

            if (axialTilt < 31.0)
            {
                return 6;
            }

            if (axialTilt < 36.0)
            {
                return 7;
            }

            if (axialTilt < 46.0)
            {
                return 8;
            }

            if (axialTilt < 61.0)
            {
                return 9;
            }

            if (axialTilt < 85.0)
            {
                return 10;
            }

            return 11;
        }





        private static short GeneratePopulation(int orbit, short size, short atmosphere, short hydro, string orbitType, int habitableZone)
        {
            int maxPop = 10;

            if (size < 4)
            {
                maxPop -= 1;
            }

            if (size < 7)
            {
                maxPop -= 1;
            }

            if (atmosphere == 5)
            {
                maxPop -= 1;
            }

            if (atmosphere == 7)
            {
                maxPop -= 1;
            }

            if (atmosphere == 9)
            {
                maxPop -= 1;
            }

            if (atmosphere == 4)
            {
                maxPop -= 2;
            }

            if (atmosphere > 12)
            {
                maxPop -= 3;
            }

            if (hydro < 3)
            {
                maxPop -= 1;
            }

            if (hydro == 10)
            {
                maxPop -= 1;
            }

            if (hydro == 0)
            {
                maxPop -= 2;
            }

            if (atmosphere < 4)
            {
                maxPop = 0;
            }

            if (atmosphere == 10)
            {
                maxPop = 0;
            }

            if (atmosphere == 11)
            {
                maxPop = 0;
            }

            if (atmosphere == 12)
            {
                maxPop = 0;
            }

            if (orbitType != OrbitTypes.Habitable)
            {
                if (orbit > habitableZone)
                {
                    maxPop = maxPop - (orbit - habitableZone) * 2;
                }
                else
                {
                    maxPop = maxPop - (habitableZone - orbit) * 2;
                }
            }

            if (maxPop < 0)
            {
                maxPop = 0;
            }

            return (short)maxPop;
        }

        private static string GenerateDensity(string orbitType)
        {
            int dieRoll = DieRoll.Roll1D6();

            if (orbitType == OrbitTypes.Outer)
            {
                dieRoll -= 2;
            }

            if (dieRoll < 2)
            {
                return PlanetDensities.Low;
            }

            if (dieRoll > 4)
            {
                return PlanetDensities.High;
            }

            return PlanetDensities.Average;
        }

        private static short GenerateHydrographic(string orbitType, short atmosphere, short size)
        {
            int dieRoll = DieRoll.Roll2D6() - 2;

            if (orbitType == OrbitTypes.Inner)
            {
                dieRoll = 0;
            }

            if (orbitType == OrbitTypes.Outer)
            {
                dieRoll -= 2;
            }

            if (atmosphere < 2)
            {
                dieRoll -= 1;
            }

            if (atmosphere < 4)
            {
                dieRoll -= 1;
            }

            if (size == 0)
            {
                dieRoll -= 4;
            }

            if (size == 1)
            {
                dieRoll -= 3;
            }

            if (size == 2)
            {
                dieRoll -= 1;
            }

            if (dieRoll < 1)
            {
                dieRoll = 0;
            }

            if (dieRoll > 10)
            {
                dieRoll = 10;
            }

            return (short) dieRoll;
        }

        private static short GenerateSize(short orbit, string stellarClassification)
        {
            int dieRoll = DieRoll.Roll2D6() - 2;

            if (orbit == 0)
            {
                dieRoll -= 5;
            }

            if (orbit == 1)
            {
                dieRoll -= 4;
            }

            if (orbit == 2)
            {
                dieRoll -= 2;
            }

            if (stellarClassification == StellarClassifications.M)
            {
                dieRoll -= 2;
            }

            if (dieRoll < 1)
            {
                dieRoll = 0;
            }

            return (short) dieRoll;
        }

        private static short GenerateAtmosphere(string orbitType, short size)
        {
            int dieRoll = DieRoll.Roll2D6() - 7 + size;

            if (orbitType == OrbitTypes.Inner)
            {
                dieRoll -= 2;
            }

            if (orbitType == OrbitTypes.Outer)
            {
                dieRoll -= 4;
            }

            if (size == 0)
            {
                dieRoll = 0;
            }

            if (dieRoll < 1)
            {
                dieRoll = 0;
            }

            return (short) dieRoll;
        }
    }
}
