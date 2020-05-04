using Common.Constants;
using Common.Helpers;

namespace Generators.StellarSystemAttributes
{
    public static class StellarDecimalNotationGenerator
    {
        public static string Generate(string classification, string luminosity)
        {
            var dieRoll = DieRoll.Roll1D10() - 1;

            if (classification == StellarClassifications.O
                && dieRoll < 5)
            {
                dieRoll = dieRoll + 5;
            }

            if (classification == StellarClassifications.K
                && luminosity.Equals(StellarLuminosities.IV)
                && dieRoll > 4)
            {
                dieRoll = dieRoll - 5;
            }

            return dieRoll.ToString();
        }
    }
}
