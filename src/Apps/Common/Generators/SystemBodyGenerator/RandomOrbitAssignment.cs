using System.Collections.Generic;
using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Helpers;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class RandomOrbitAssignment
    {
        public static void Assign(List<Orbit> orbits, int numberToAssign, string assignmentType, int rollAdjustment = 0)
        {
            int i = numberToAssign;
            int hitCount = 0;
            while (i > 0)
            {
                int roll = DieRoll.Roll2D6() + rollAdjustment;

                if (roll > SystemConstants.MaxOrbits)
                {
                    roll = SystemConstants.MaxOrbits - 1;
                }

                var orbit = orbits[roll];

                if (orbit.OccupiedType is null)
                {
                    orbit.OccupiedType = assignmentType;
                    i--;
                }
                else
                {
                    hitCount++;

                    if (hitCount > 100)
                    {
                        //Give up and don't place empty orbits.
                        break;
                    }
                }
            }
        }
    }
}
