using System;
using Common.Constants;

namespace Generators.StellarSystemAttributes
{
    public static class StellarMassGenerator
    {
        public static double Generate(string classification, string decimalNotation, string luminosity)
        {
            int starSize = 0;

            switch (classification)
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

            double x = Convert.ToDouble(decimalNotation);
            double a = 0.0;
            double b = 0.0;

            switch (luminosity)
            {
                case StellarLuminosities.Ia:
                    a = StellarMassTables.TableIa[starSize];
                    b = StellarMassTables.TableIa[starSize + 1];
                    break;
                case StellarLuminosities.Ib:
                    a = StellarMassTables.TableIb[starSize];
                    b = StellarMassTables.TableIb[starSize + 1];
                    break;
                case StellarLuminosities.II:
                    a = StellarMassTables.TableII[starSize];
                    b = StellarMassTables.TableII[starSize + 1];
                    break;
                case StellarLuminosities.III:
                    a = StellarMassTables.TableIII[starSize];
                    b = StellarMassTables.TableIII[starSize + 1];
                    break;
                case StellarLuminosities.IV:
                    a = StellarMassTables.TableIV[starSize];
                    b = StellarMassTables.TableIV[starSize + 1];
                    break;
                case StellarLuminosities.V:
                    a = StellarMassTables.TableV[starSize];
                    b = StellarMassTables.TableV[starSize + 1];
                    break;
                case StellarLuminosities.D:
                    a = StellarMassTables.TableD[starSize];
                    b = StellarMassTables.TableD[starSize + 1];
                    break;
            }

            double result = (((b - a) / 5) * x) + a;
            return result;
        }
    }
}
