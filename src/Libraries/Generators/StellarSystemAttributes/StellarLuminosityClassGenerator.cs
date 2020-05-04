using System;
using Common.Constants;
using Common.Helpers;

namespace Generators.StellarSystemAttributes
{
    public static class StellarLuminosityClassGenerator
    {
        public static string Generate(string stellarClassification, string primaryLuminosity = null)
        {
            /* Check for rare values */
            int dieRoll;

            if (primaryLuminosity == null)
            {
                dieRoll = DieRoll.Roll3D6();

                if (dieRoll == 3) return (StellarLuminosities.Ia);
                if (dieRoll == 4) return (StellarLuminosities.Ib);
            }

            dieRoll = DieRoll.Roll2D6() + GetModifier(primaryLuminosity);

            switch (dieRoll)
            {
                case 2:
                    return StellarLuminosities.II; 
                case 3:
                    return StellarLuminosities.III;
                case 4:
                    if (stellarClassification == StellarClassifications.M)
                        return StellarLuminosities.V;
                    else
                        return StellarLuminosities.IV;
                case 5:
                    return StellarLuminosities.V;
                case 6:
                    return StellarLuminosities.V;
                case 7:
                    return StellarLuminosities.V;
                case 8:
                    return StellarLuminosities.V;
                case 9:
                    return StellarLuminosities.V;
                case 10:
                    return StellarLuminosities.V;
                case 11:
                    return StellarLuminosities.V;
                case 12:
                    return StellarLuminosities.V;
                case 13:
                    return StellarLuminosities.V;
                default:
                    if (DieRoll.Roll1D6() < 4)
                    {
                        return StellarLuminosities.V;
                    }
                    else
                    {
                        return StellarLuminosities.D;
                    }
            }

            throw new Exception("Unsupported Type");
        }

        private static int GetModifier(string primaryLuminosity)
        {
            if (primaryLuminosity == null)
            {
                return 0;
            }

            switch (primaryLuminosity.ToLower())
            {
                case StellarLuminosities.Ia:
                    return 2;
                case StellarLuminosities.Ib:
                    return 2;
                case StellarLuminosities.I:
                    return 2;
                case StellarLuminosities.II:
                    return 2;
                case StellarLuminosities.III:
                    return 3;
                case StellarLuminosities.IV:
                    return 4;
                case StellarLuminosities.V:
                    return 5;
                case StellarLuminosities.D:
                    return 0;
            }

            return 0;
        }
    }
}
