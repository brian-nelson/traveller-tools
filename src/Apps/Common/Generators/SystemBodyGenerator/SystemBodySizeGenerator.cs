using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Helpers;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class SystemBodySizeGenerator
    {
        public static short Generate(short orbit, string stellarClassification)
        {
            int dieRoll = DieRoll.Roll2D6() - 2;

            if (orbit == 0)
            {
                dieRoll -= 5;
            }

            if (orbit == 1)
            {
                dieRoll -= 4;
            }

            if (orbit == 2)
            {
                dieRoll -= 2;
            }

            if (stellarClassification == StellarClassifications.M)
            {
                dieRoll -= 2;
            }

            if (dieRoll < 1)
            {
                dieRoll = 0;
            }

            return (short)dieRoll;
        }
    }
}
