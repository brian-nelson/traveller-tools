using System;
using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Helpers;
using TravellerUtils.Libraries.Common.Interfaces;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class SatelliteGenerator
    {
        public static ISystemBody Generate(int worldSize, double orbitalDistance,
            string occupiedType, int orbitNumber, string orbitType, string stellarClassification,
            double planetDiameter, string planetDensity, double luminosity, int habitableZone)
        {
            int satelliteSize = GenerateSatelliteSize(worldSize);
            string density = GenerateDensity(orbitType);
            short atmosphere = GenerateAtmosphere(orbitType, worldSize);
            int hydrographics = GenerateHydrographics(orbitType, satelliteSize, atmosphere);
            int maxPopulation = GenerateMaxPopulation(orbitNumber, orbitType, satelliteSize, 
                atmosphere, hydrographics, habitableZone);

            int satelliteOrbitNumber = GenerateSatelliteOrbitNumber();
            double satelliteOrbitalDistance = planetDiameter / 2 * orbitNumber;

            double planetMass = PlanetVolumeGenerator.Generate(planetDiameter, planetDensity);

            double orbitPeriod = Math.Sqrt((Math.Pow((satelliteOrbitalDistance / 400000), 3) * 793.64) / planetMass);
            double rotationPeriod = (4 * (DieRoll.Roll2D6() - 2)) + 5;
            double orbitFactor = SystemConstants.HabitNum / Math.Sqrt(orbitalDistance);
            short atmosphereCode = AtmosphereCodeGenerator.Generate(atmosphere);
                = GenerateEnergyAbsorption(orbitType, hydrographics, atmosphereCode);

            return null;
        }

        private static int GenerateSatelliteOrbitNumber()
        {
            int dieRoll = DieRoll.Roll2D6();

            if (dieRoll < 8)
            {
                switch (DieRoll.Roll2D6())
                {
                    case 2:
                    {
                        return 3;
                    }
                    case 3:
                    {
                        return 4;
                    }
                    case 4:
                    {
                        return 5;
                    }
                    case 5:
                    {
                        return 6;
                    }
                    case 6:
                    {
                        return 7;
                    }
                    case 7:
                    {
                        return 8;
                    }
                    case 8:
                    {
                        return 9;
                    }
                    case 9:
                    {
                        return 10;
                    }
                    case 10:
                    {
                        return 11;
                    }
                    case 11:
                    {
                        return 12;
                    }
                    case 12:
                    {
                        return 12;
                    }
                }
            }
            else if (dieRoll < 12)
            {
                switch (DieRoll.Roll2D6())
                {
                    case 2:
                    {
                        return 15;
                    }
                    case 3:
                    {
                        return 20;
                    }
                    case 4:
                    {
                        return 25;
                    }
                    case 5:
                    {
                        return 30;
                    }
                    case 6:
                    {
                        return 35;
                    }
                    case 7:
                    {
                        return 40;
                    }
                    case 8:
                    {
                        return 45;
                    }
                    case 9:
                    {
                        return 50;
                    }
                    case 10:
                    {
                        return 55;
                    }
                    case 11:
                    {
                        return 60;
                    }
                    case 12:
                    {
                        return 65;
                    }
                }
            }
            else
            {
                switch (DieRoll.Roll2D6())
                {
                    case 2:
                    {
                        return 75;
                    }
                    case 3:
                    {
                        return 100;
                    }
                    case 4:
                    {
                        return 125;
                    }
                    case 5:
                    {
                        return 150;
                    }
                    case 6:
                    {
                        return 175;
                    }
                    case 7:
                    {
                        return 200;
                    }
                    case 8:
                    {
                        return 225;
                    }
                    case 9:
                    {
                        return 250;
                    }
                    case 10:
                    {
                        return 275;
                    }
                    case 11:
                    {
                        return 300;
                    }
                    case 12:
                    {
                        return 325;
                    }
                }
            }

            return 12;
        }

        private static int GenerateMaxPopulation(int orbitNumber, string orbitType, 
            int satelliteSize, int atmosphere, int hydrographics, int habitableZone)
        {
            int maxPop = 10;
            if (satelliteSize < 4)
            {
                maxPop -= 1;
            }

            if (satelliteSize < 7)
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

            if (hydrographics < 3)
            {
                maxPop -= 1;
            }

            if (hydrographics == 10)
            {
                maxPop -= 1;
            }

            if (hydrographics == 0)
            {
                maxPop -= 2;
            }

            if (atmosphere < 4)
            {
                maxPop = 0;
            }

            if (atmosphere > 9)
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
                if (orbitNumber > habitableZone)
                {
                    maxPop = maxPop - (orbitNumber - habitableZone) * 2;
                }
                else
                {
                    maxPop = maxPop - (habitableZone - orbitNumber) * 2;
                }
            }

            if (maxPop < 0)
            {
                maxPop = 0;
            }

            return maxPop;
        }

        private static int GenerateHydrographics(string orbitType, int satelliteSize, int atmosphere)
        {
            int dieRoll = DieRoll.Roll2D6() - 2;

            if (orbitType.Equals(OrbitTypes.Inner))
            {
                dieRoll = 0;
            }

            if (orbitType.Equals(OrbitTypes.Outer))
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

            if (satelliteSize == 0)
            {
                dieRoll -= 4;
            }

            if (satelliteSize == 1)
            {
                dieRoll -= 3;
            }

            if (satelliteSize == 2)
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

            return dieRoll;
        }

        private static short GenerateAtmosphere(string orbitType, int size)
        {
            int dieRoll = DieRoll.Roll2D6() - 7 + size;

            if (orbitType.Equals(OrbitTypes.Inner))
            {
                dieRoll -= 2;
            }

            if (orbitType.Equals(OrbitTypes.Outer))
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

            return (short)dieRoll;
        }

        private static string GenerateDensity(string orbitType)
        {
            int dieRoll = DieRoll.Roll1D6();

            if (orbitType.Equals(OrbitTypes.Outer))
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

        private static int GenerateSatelliteSize(int worldSize)
        {
            int dieRoll;

            if (worldSize == -1) /* Small Gas Giant */
            {
                dieRoll = DieRoll.Roll2D6() - 6;
            }
            else if (worldSize == -2) /* Large Gas Giant */
            {
                dieRoll = DieRoll.Roll2D6() - 4;
            }
            else
            {
                dieRoll = DieRoll.Roll1D6() - 3;
            }

            if (dieRoll == 0)
            {
                //Ring
                return 0;
            }

            if (dieRoll >= worldSize
                && worldSize >= 0)
            {
                dieRoll = worldSize - 1;
            }

            if (dieRoll < 1)
            {
                dieRoll = 0;
            }

            return dieRoll;
        }
    }
}
