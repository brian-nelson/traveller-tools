using System;
using System.Collections.Generic;
using System.Text;
using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Interfaces;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class SystemBodiesGenerator
    {
        public static List<ISystemBody> Generate(List<Star> stars, int starToGenerate)
        {
            var star = stars[starToGenerate - 1];
            var orbits = OrbitsGenerator.Generate(stars);

            List<ISystemBody> output = new List<ISystemBody>();

            for (int i = 0; i < SystemConstants.MaxOrbits; i++)
            {
                Orbit o = orbits[i];

                switch (o.OrbitType)
                {
                    case OrbitTypes.Unavailable:
                        //Remove objects that can't exist due to orbit not being available
                        o.OccupiedType = null;
                        break;
                    case OrbitTypes.Inner:
                        if (o.OccupiedType == null)
                        {
                            o.OccupiedType = OccupiedTypes.World;
                        }
                        break;
                    case OrbitTypes.Habitable:
                        if (o.OccupiedType == null)
                        {
                            o.OccupiedType = OccupiedTypes.World;
                        }
                        break;
                    case OrbitTypes.Outer:
                        if (o.OccupiedType == null)
                        {
                            o.OccupiedType = OccupiedTypes.World;
                        }
                        break;
                }

                if (o.OccupiedType != null)
                {
                    var systemBody = SystemBodyGenerator.Generate((short)i, o.Range, o.OccupiedType, o.OrbitType,
                        star.Classification, star.Mass, star.Luminosity, star.HabitableZone);
                    output.Add(systemBody);
                }
            }

            return output;
        }
    }
}
