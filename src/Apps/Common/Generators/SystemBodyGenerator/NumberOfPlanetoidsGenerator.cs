using System;
using TravellerUtils.Libraries.Common.Helpers;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class NumberOfPlanetoidsGenerator
    {
        public static short Generate()
        {
            int dieRoll = DieRoll.Roll2D6();

            if (dieRoll < 8) return (0);

            dieRoll = DieRoll.Roll2D6();

            switch (dieRoll)
            {
                case 2: 
                    return 1;
                case 3: 
                    return 1;
                case 4: 
                    return 1;
                case 5: 
                    return 1;
                case 6: 
                    return 1;
                case 7: 
                    return 2;
                case 8: 
                    return 2;
                case 9: 
                    return 2;
                case 10: 
                    return 2;
                case 11: 
                    return 2;
                case 12: 
                    return 3;
            }

            throw new Exception("Unexpected die roll");
        }
    }
}
