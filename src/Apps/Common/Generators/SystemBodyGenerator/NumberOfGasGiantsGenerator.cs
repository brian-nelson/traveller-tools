using System;
using TravellerUtils.Libraries.Common.Helpers;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class NumberOfGasGiantsGenerator
    {
        public static short Generate(string classification)
        {
            int dieroll = DieRoll.Roll2D6();

            if (dieroll < 5) return (0);

            dieroll = DieRoll.Roll2D6();

            switch (dieroll)
            {
                case 2: 
                    return 1;
                case 3: 
                    return 1;
                case 4: 
                    return 2;
                case 5: 
                    return 2;
                case 6: 
                    return 3;
                case 7: 
                    return 3;
                case 8: 
                    return 4;
                case 9: 
                    return 4;
                case 10: 
                    return 4;
                case 11: 
                    return 5;
                case 12: 
                    return 5;
            }

            throw new Exception("Unexpected die roll");
        }
    }
}
