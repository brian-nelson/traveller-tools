using System.Collections.Generic;
using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Generators.StellarSystemAttributes;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class OrbitsGenerator
    {
        public static List<Orbit> Generate(List<Star> stars, int starToGenerate = 1)
        {
            Star primaryStar = stars[0];
            Star secondaryStar = null;
            if (stars.Count > 1)
            {
                secondaryStar = stars[1];
            }

            Star tertiaryStar = null;
            if (stars.Count > 2)
            {
                tertiaryStar = stars[2];
            }
            
            List<Orbit> output = new List<Orbit>();

            int habitableZone = -2;

            for (short i = 0; i < SystemConstants.MaxOrbits; i++)
            {
                double range = OrbitRangeGenerator.Generate(i);

                Orbit o = new Orbit
                {
                    Range = range, 
                    OccupiedType = null,
                    OrbitType = OrbitTypeGenerator.Generate(range, primaryStar.Luminosity, 0)
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

            stars[starToGenerate - 1].HabitableZone = habitableZone;

            int numberOfOrbits = NumberOfOrbitsGenerator.Generate(primaryStar.Classification, primaryStar.LuminosityClass);
            
            int emptyOrbits = NumberOfEmptyOrbitsGenerator.Generate(primaryStar.Classification);
            RandomOrbitAssignment.Assign(output, emptyOrbits, OccupiedTypes.Empty, -2);

            int capturedPlanets = NumberOfCapturedPlanetsGenerator.Generate(primaryStar.Classification);
            RandomOrbitAssignment.Assign(output, capturedPlanets, OccupiedTypes.CapturedPlanet);

            int gasGiants = NumberOfGasGiantsGenerator.Generate(primaryStar.Classification);
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

            if (secondaryStar != null)
            {
                short secondaryOrbit = CompanionStarOrbitGenerator.Generate();

                if (secondaryOrbit < 99)
                {
                    if (secondaryOrbit > 2)
                    {
                        for (int i = secondaryOrbit / 2; i < secondaryOrbit; i++)
                        {
                            Orbit o = output[i];
                            o.OrbitType = OrbitTypes.Star;
                            o.OccupiedType = null;
                        }
                    }
                    else
                    {
                        Orbit o = output[secondaryOrbit];
                        o.OccupiedType = OccupiedTypes.Star;
                        o.OrbitType = OrbitTypes.Star;

                        o = output[secondaryOrbit + 1];
                        o.OccupiedType = null;
                        o.OrbitType = OrbitTypes.Star;
                    }
                }

                secondaryStar.Orbit = secondaryOrbit;
            }

            //Thirt stars a pushed to a far orbit
            if (tertiaryStar != null)
            {
                tertiaryStar.Orbit = 99;
            }

            return output;
        }
    }
}
