using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Helpers;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class NumberOfEmptyOrbitsGenerator
    {
        public static int Generate(string classification)
        {
            int dieRoll = DieRoll.Roll1D6();

            if (classification == StellarClassifications.A
                || classification == StellarClassifications.B)
            {
                dieRoll++;
            }

            if (dieRoll < 5)
            {
                return 0;
            }

            dieRoll = DieRoll.Roll1D6();

            if (classification == StellarClassifications.A
                || classification == StellarClassifications.B)
            {
                dieRoll++;
            }

            switch (dieRoll)
            {
                case 1: 
                    return 1;
                case 2: 
                    return 1;
                case 3: 
                    return 2;
                case 4: 
                    return 3;
                case 5: 
                    return 3;
                default: 
                    return 3;
            }
        }
    }
}
