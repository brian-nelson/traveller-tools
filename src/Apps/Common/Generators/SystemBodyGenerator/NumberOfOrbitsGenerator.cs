using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Helpers;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class NumberOfOrbitsGenerator
    {
        public static short Generate(string classification, string luminosityClassification)
        {
            int dieRoll = DieRoll.Roll2D6();

            /* Class O stars (Blue) are still forming */
            if (classification == StellarClassifications.O) return 0;

            if (luminosityClassification == StellarLuminosities.I)
            {
                dieRoll = dieRoll + 8;
            }

            if (luminosityClassification == StellarLuminosities.Ia)
            {
                dieRoll = dieRoll + 8;
            }

            if (luminosityClassification == StellarLuminosities.Ib)
            {
                dieRoll = dieRoll + 8;
            }

            if (luminosityClassification == StellarLuminosities.II)
            {
                dieRoll = dieRoll + 8;
            }

            if (luminosityClassification == StellarLuminosities.III)
            {
                dieRoll = dieRoll + 4;
            }

            if (luminosityClassification == StellarLuminosities.IV)
            {
                dieRoll = dieRoll + 2;
            }

            if (classification == StellarClassifications.K)
            {
                dieRoll = dieRoll - 2;
            }

            if (classification == StellarClassifications.M)
            {
                dieRoll = dieRoll - 4;
            }

            if (dieRoll < 0)
            {
                return 0;
            }

            if (dieRoll > 19)
            {
                return 19;
            }

            return (short)dieRoll;
        }
    }
}
