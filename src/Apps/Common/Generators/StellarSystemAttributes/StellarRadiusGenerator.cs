using System;
using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Enums;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Generators.StellarSystemAttributes
{
    public static class StellarRadiusGenerator
    {
        public static Distance Generate(string classification, string decimalNotation, string luminosity)
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
                    a = StellarRadiusTables.TableIa[starSize];
                    b = StellarRadiusTables.TableIa[starSize + 1];
                    break;
                case StellarLuminosities.Ib:
                    a = StellarRadiusTables.TableIb[starSize];
                    b = StellarRadiusTables.TableIb[starSize + 1];
                    break;
                case StellarLuminosities.II:
                    a = StellarRadiusTables.TableII[starSize];
                    b = StellarRadiusTables.TableII[starSize + 1];
                    break;
                case StellarLuminosities.III:
                    a = StellarRadiusTables.TableIII[starSize];
                    b = StellarRadiusTables.TableIII[starSize + 1];
                    break;
                case StellarLuminosities.IV:
                    a = StellarRadiusTables.TableIV[starSize];
                    b = StellarRadiusTables.TableIV[starSize + 1];
                    break;
                case StellarLuminosities.V:
                    a = StellarRadiusTables.TableV[starSize];
                    b = StellarRadiusTables.TableV[starSize + 1];
                    break;
                case StellarLuminosities.D:
                    a = StellarRadiusTables.TableD[starSize];
                    b = StellarRadiusTables.TableD[starSize + 1];
                    break;
            }

            double result = (((b - a) / 5) * x) + a;

            Distance output = new Distance
            {
                Value = result,
                Units = DistanceUnits.StellarRadius
            };

            return output;
        }
    }
}
