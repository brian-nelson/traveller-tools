using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Enums;
using TravellerUtils.Libraries.Common.Helpers;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class PlanetDiameterGenerator
    {
        public static Distance Generate(string occupiedType, int size)
        {
            double planetDiameter = 0;

            if (occupiedType.Equals(OccupiedTypes.GasGiant))
            {
                switch (size)
                {
                    case -1:
                        planetDiameter = 20000 + PerturbHelper.Change(20000);
                        break;
                    case -2:
                        planetDiameter = 60000 + PerturbHelper.Change(100000);
                        break;
                }
            }
            else if (occupiedType.Equals(OccupiedTypes.CapturedPlanet)
                     || occupiedType.Equals(OccupiedTypes.World))
            {
                switch (size)
                {
                    case 0: 
                        planetDiameter = 200 + PerturbHelper.Change(300); 
                        break;
                    case 1: 
                        planetDiameter = 800 + PerturbHelper.Change(800); 
                        break;
                    case 2: 
                        planetDiameter = 2400 + PerturbHelper.Change(1600); 
                        break;
                    case 3: 
                        planetDiameter = 4000 + PerturbHelper.Change(800); 
                        break;
                    case 4: 
                        planetDiameter = 5600 + PerturbHelper.Change(800); 
                        break;
                    case 5: 
                        planetDiameter = 7200 + PerturbHelper.Change(800); 
                        break;
                    case 6: 
                        planetDiameter = 8800 + PerturbHelper.Change(800); 
                        break;
                    case 7: 
                        planetDiameter = 10400 + PerturbHelper.Change(800); 
                        break;
                    case 8: 
                        planetDiameter = 12000 + PerturbHelper.Change(800); 
                        break;
                    case 9: 
                        planetDiameter = 13600 + PerturbHelper.Change(800); 
                        break;
                    case 10:
                        planetDiameter = 15200 + PerturbHelper.Change(800); 
                        break;
                }
            }

            Distance distance = new Distance {Value = planetDiameter, Units = DistanceUnits.Kilometer};

            return distance;
        }
    }
}
