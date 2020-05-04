using System;
using TravellerUtils.Libraries.Common.Constants;

namespace TravellerUtils.Libraries.Common.Generators.StellarSystemAttributes
{
    public static class StellarLuminosityGenerator
    {
        public static double Generate(string stellarClassification, string decimalClass, string luminosityClass)
        {
            int starSize = 0;
            
            switch (stellarClassification)
            {
                case StellarClassifications.O: 
                    starSize = 0; 
                    break;
                case StellarClassifications.B: 
                    starSize = 0; 
                    break;
                case StellarClassifications.A: 
                    starSize = 2; 
                    break;
                case StellarClassifications.F: 
                    starSize = 4; 
                    break;
                case StellarClassifications.G: 
                    starSize = 6; 
                    break;
                case StellarClassifications.K: 
                    starSize = 8; 
                    break;
                case StellarClassifications.M: 
                    starSize = 10; 
                    break;
            }

            double x = Convert.ToDouble(decimalClass);
            double a = 0;
            double b = 0;

            switch (luminosityClass)
            {
                case StellarLuminosities.Ia:
                    a = StellarLuminosityTables.TableIa[starSize];
                    b = StellarLuminosityTables.TableIa[starSize + 1];
                    if (stellarClassification == StellarClassifications.M
                        && decimalClass == "9")
                    {
                        return (StellarLuminosityTables.TableIa[12]);
                    }
                    break;
                case StellarLuminosities.Ib:
                    a = StellarLuminosityTables.TableIb[starSize];
                    b = StellarLuminosityTables.TableIb[starSize + 1];
                    if (stellarClassification == StellarClassifications.M
                        && decimalClass == "9")
                    {
                        return (StellarLuminosityTables.TableIb[12]);
                    }
                    break;
                case StellarLuminosities.II:
                    a = StellarLuminosityTables.TableII[starSize];
                    b = StellarLuminosityTables.TableII[starSize + 1];
                    if (stellarClassification == StellarClassifications.M
                        && decimalClass == "9")
                    {
                        return (StellarLuminosityTables.TableII[12]);
                    }
                    break;
                case StellarLuminosities.III:
                    a = StellarLuminosityTables.TableIII[starSize];
                    b = StellarLuminosityTables.TableIII[starSize + 1];
                    if (stellarClassification == StellarClassifications.M
                        && decimalClass == "9")
                    {
                        return (StellarLuminosityTables.TableIII[12]);
                    }
                    break;
                case StellarLuminosities.IV:
                    a = StellarLuminosityTables.TableIV[starSize];
                    b = StellarLuminosityTables.TableIV[starSize + 1];
                    if (stellarClassification == StellarClassifications.M
                        && decimalClass == "9")
                    {
                        return (StellarLuminosityTables.TableIV[12]);
                    }
                    break;
                case StellarLuminosities.V:
                    a = StellarLuminosityTables.TableV[starSize];
                    b = StellarLuminosityTables.TableV[starSize + 1];
                    if (stellarClassification == StellarClassifications.M
                        && decimalClass == "9")
                    {
                        return (StellarLuminosityTables.TableV[12]);
                    }
                    break;
                case StellarLuminosities.D:
                    a = StellarLuminosityTables.TableD[starSize];
                    b = StellarLuminosityTables.TableD[starSize + 1];
                    if (stellarClassification == StellarClassifications.M
                        && decimalClass == "9")
                    {
                        return (StellarLuminosityTables.TableD[12]);
                    }
                    break;
            }

            return (((b - a) / 5) * x) + a;
        }
    }
}
