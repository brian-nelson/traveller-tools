using TravellerUtils.Libraries.Common.Helpers;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class OrbitalEccentricityGenerator
    {
        public static double Generate()
        {
            int dieRoll = DieRoll.Roll2D6();

            switch (dieRoll)
            {
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7: 
                    return 0.0; 
                case 8: 
                    return 0.005;
                case 9: 
                    return 0.010;
                case 10: 
                    return 0.015;
                case 11: 
                    return 0.020;
                default:
                    dieRoll = DieRoll.Roll2D6();

                    switch (dieRoll)
                    {
                        case 1: 
                            return 0.025;
                        case 2: 
                            return 0.050;
                        case 3: 
                            return 0.100;
                        case 4: 
                            return 0.200;
                        case 5: 
                            return 0.250;
                        default:
                            return 0.300;
                    }
            }
        }
    }
}
