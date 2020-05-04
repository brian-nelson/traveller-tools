using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Helpers;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class NumberOfCapturedPlanetsGenerator
    {
        public static short Generate(string classification)
        {
            int dieroll = DieRoll.Roll1D6();

            if (classification == StellarClassifications.A
                || classification == StellarClassifications.B)
            {
                dieroll++;
            }

            if (dieroll < 5)
            {
                return 0;
            }

            dieroll = DieRoll.Roll1D6();

            switch (dieroll)
            {
                case 1: 
                    return 1;
                case 2: 
                    return 1;
                case 3: 
                    return 1;
                case 4: 
                    return 2;
                case 5: 
                    return 2;
                default: 
                    return 3;
            }
        }
    }
}
