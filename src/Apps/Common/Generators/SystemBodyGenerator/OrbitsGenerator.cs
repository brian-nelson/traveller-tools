using System;
using System.Collections.Generic;
using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Generators.StellarSystemAttributes;
using TravellerUtils.Libraries.Common.Helpers;
using TravellerUtils.Libraries.Common.Interfaces;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class OrbitsGenerator
    {
        public static List<Orbit> Generate(StellarSystem stellarSystem, int starToGenerate = 1)
        {
            Star primaryStar = (Star)stellarSystem.Stars[0];

            CompanionStar secondaryStar = null;
            if (stellarSystem.Stars.Count > 1)
            {
                secondaryStar = (CompanionStar) stellarSystem.Stars[1];
            }

            CompanionStar tertiaryStar = null;
            if (stellarSystem.Stars.Count > 2)
            {
                tertiaryStar = (CompanionStar) stellarSystem.Stars[2];
            }

            IStar currentStar = stellarSystem.Stars[starToGenerate - 1];
            
            List<Orbit> output = new List<Orbit>();

            int habitableZone = -2;

            for (short i = 0; i < SystemConstants.MaxOrbits; i++)
            {
                Distance orbitalDistance;

                if (currentStar == primaryStar
                    || currentStar == tertiaryStar)           //All tertiary stars are put at far orbit 
                {
                    orbitalDistance = OrbitRangeGenerator.Generate(i);
                }
                else
                {
                    orbitalDistance = CompanionStarOrbitalDistanceGenerator.Generate(primaryStar, secondaryStar, i);
                }

                Orbit o = new Orbit
                {
                    OrbitalDistance = orbitalDistance, 
                    OccupiedType = null,
                    OrbitType = OrbitTypeGenerator.Generate(orbitalDistance, primaryStar.Luminosity, 0)
                };

                if (o.OrbitType == OrbitTypes.Habitable)
                {
                    habitableZone = i;
                }

                if (o.OrbitType == OrbitTypes.Outer
                    && habitableZone == -2)
                {
                    habitableZone = i - 1;
                }

                output.Add(o);
            }

            if (habitableZone == -2)
            {
                habitableZone = 10;
            }

            currentStar.HabitableZone = (short)habitableZone;

            int numberOfOrbits = NumberOfOrbitsGenerator.Generate(currentStar.Classification, currentStar.LuminosityClass);
            
            int emptyOrbits = NumberOfEmptyOrbitsGenerator.Generate(currentStar.Classification);
            RandomOrbitAssignment.Assign(output, emptyOrbits, OccupiedTypes.Empty, -2);

            int capturedPlanets = NumberOfCapturedPlanetsGenerator.Generate(currentStar.Classification);
            RandomOrbitAssignment.Assign(output, capturedPlanets, OccupiedTypes.CapturedPlanet);

            int gasGiants = NumberOfGasGiantsGenerator.Generate(currentStar.Classification);
            RandomOrbitAssignment.Assign(output, gasGiants, OccupiedTypes.GasGiant, -3 + habitableZone);

            int planetoids = NumberOfPlanetoidsGenerator.Generate();
            //Note Slight deviation from source.
            RandomOrbitAssignment.Assign(output, planetoids, OccupiedTypes.Planetoid, -1);

            //Clear out orbits in excess of Number of Orbits, but keep captured planets
            for (int i = 0; i < SystemConstants.MaxOrbits; i++)
            {
                Orbit o = output[i];

                if (i > numberOfOrbits)
                {
                    if (o.OccupiedType != OccupiedTypes.CapturedPlanet)
                    {
                        o.OccupiedType = null;
                    }
                }
                else
                {
                    if (o.OccupiedType == OccupiedTypes.Empty)
                    {
                        o.OccupiedType = null;
                    }
                }
            }

            if (secondaryStar != null
                && currentStar == primaryStar)
            {
                secondaryStar.OrbitNumber = CompanionStarOrbitGenerator.Generate();

                if (secondaryStar.OrbitNumber < 99)
                {
                    if (secondaryStar.OrbitNumber > 2)
                    {
                        for (int i = secondaryStar.OrbitNumber / 2; i < secondaryStar.OrbitNumber; i++)
                        {
                            Orbit o = output[i];
                            o.OrbitType = OrbitTypes.Star;
                            o.OccupiedType = null;
                        }
                    }
                    else
                    {
                        Orbit o = output[secondaryStar.OrbitNumber];
                        o.OccupiedType = OccupiedTypes.Star;
                        o.OrbitType = OrbitTypes.Star;

                        o = output[secondaryStar.OrbitNumber + 1];
                        o.OccupiedType = null;
                        o.OrbitType = OrbitTypes.Star;
                    }

                    secondaryStar.OrbitalDistance = output[secondaryStar.OrbitNumber].OrbitalDistance;

                    stellarSystem.CombinedLuminosity += SystemConstants.HabitNum /
                                                        Math.Sqrt(secondaryStar.OrbitalDistance.ToAstronomicalUnits().Value);
                }
                else
                {
                    //No impact on luminosity
                    secondaryStar.OrbitalDistance = FarOrbitDistanceGenerator.Generate();
                }

                secondaryStar.OrbitalPeriod = OrbitalPeriodGenerator.Generate(primaryStar, secondaryStar);
                secondaryStar.OrbitEccentricity = OrbitalEccentricityGenerator.Generate();
                secondaryStar.AxialTilt = AxialTiltGenerator.Generate();
                secondaryStar.AxialTiltEffect = TiltEffectGenerator.Generate(secondaryStar.AxialTilt);
            }

            //Third stars a pushed to a far orbit
            //No impact on luminosity
            if (tertiaryStar != null
                && currentStar == primaryStar)
            {
                if (secondaryStar.OrbitNumber == 99)
                {
                    tertiaryStar.OrbitNumber = 100;
                }
                else
                {
                    tertiaryStar.OrbitNumber = 99;
                }
                
                tertiaryStar.OrbitalDistance = FarOrbitDistanceGenerator.Generate();
                tertiaryStar.OrbitalPeriod = OrbitalPeriodGenerator.Generate(primaryStar, tertiaryStar);
                tertiaryStar.OrbitEccentricity = OrbitalEccentricityGenerator.Generate();
                tertiaryStar.AxialTilt = AxialTiltGenerator.Generate();
                tertiaryStar.AxialTiltEffect = TiltEffectGenerator.Generate(tertiaryStar.AxialTilt);
            }

            return output;
        }
    }
}
