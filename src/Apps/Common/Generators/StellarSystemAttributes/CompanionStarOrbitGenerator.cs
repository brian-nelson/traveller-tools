using System;
using TravellerUtils.Libraries.Common.Helpers;

namespace TravellerUtils.Libraries.Common.Generators.StellarSystemAttributes
{
    public static class CompanionStarOrbitGenerator
    {
        public static short Generate()
        {
            int dieRoll = DieRoll.Roll2D6();

            switch (dieRoll)
            {
                case 2: return 0;
                case 3: return 0;
                case 4: return 1;
                case 5: return 2;
                case 6: return 3;
                case 7: return (short)(4 + DieRoll.Roll1D6());
                case 8: return (short)(5 + DieRoll.Roll1D6()); 
                case 9: return (short)(6 + DieRoll.Roll1D6());
                case 10: return (short)(7 + DieRoll.Roll1D6());
                case 11: return (short)(8 + DieRoll.Roll1D6());
                case 12: return 99;
            }

            throw new Exception("Unexpected die roll");
        }
    }
}
