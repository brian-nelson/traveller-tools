using System;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class TimeGenerator
    {
        public static double GenerateDayTime(short atmosphere, double rotationPeriod, double luminosity, double distance,
            double temperature)
        {
            double x;
            double max;
            double dayLength = rotationPeriod / 2;

            var r = luminosity / Math.Sqrt(distance);

            switch (atmosphere)
            {
                case 0:
                    x = 1.0 * r * dayLength;
                    max = 0.1 * (temperature + 273) * r;
                    if (x > max)
                    {
                        x = max;
                    }

                    return x;
                case 1:
                    x = 0.9 * r * dayLength;
                    max = 0.3 * (temperature + 273) * r;
                    if (x > max)
                    {
                        x = max;
                    }

                    return x;
                case 2:
                case 3:
                case 14:
                    x = 0.8 * r * dayLength;
                    max = 0.8 * (temperature + 273) * r;
                    if (x > max)
                    {
                        x = max;
                    }

                    return x;
                case 4:
                case 5:
                    x = 0.6 * r * dayLength;
                    max = 1.5 * (temperature + 273) * r;
                    if (x > max)
                    {
                        x = max;
                    }

                    return x;
                case 6:
                case 7:
                    x = 0.5 * r * dayLength;
                    max = 2.5 * (temperature + 273) * r;
                    if (x > max)
                    {
                        x = max;
                    }

                    return x;
                case 8:
                case 9:
                    x = 0.4 * r * dayLength;
                    max = 4.0 * (temperature + 273) * r;
                    if (x > max)
                    {
                        x = max;
                    }

                    return x;
                default:
                    x = 0.2 * r * dayLength;
                    max = 5.0 * (temperature + 273) * r;
                    if (x > max)
                    {
                        x = max;
                    }

                    return x;
            }
        }

        public static double GenerateNightTime(short atmosphere, double rotationPeriod, double temperature)
        {
            double x;
            double max;
            double dayLength = rotationPeriod / 2;

            switch (atmosphere)
            {
                case 0:
                    x = 20.0 * dayLength;
                    max = 0.80 * (temperature + 273);
                    if (x > max)
                    {
                        x = max;
                    }

                    return -x;
                case 1:
                    x = 15.0 * dayLength;
                    max = 0.70 * (temperature + 273);
                    if (x > max)
                    {
                        x = max;
                    }

                    return -x;
                case 2:
                case 3:
                case 14:
                    x = 8.0 * dayLength;
                    max = 0.50 * (temperature + 273);
                    if (x > max)
                    {
                        x = max;
                    }

                    return -x;
                case 4:
                case 5:
                    x = 3.0 * dayLength;
                    max = 0.30 * (temperature + 273);
                    if (x > max)
                    {
                        x = max;
                    }

                    return -x;
                case 6:
                case 7:
                    x = 1.0 * dayLength;
                    max = 0.15 * (temperature + 273);
                    if (x > max)
                    {
                        x = max;
                    }

                    return (-x);
                case 8:
                case 9:
                    x = 0.5 * dayLength;
                    max = 0.10 * (temperature + 273);
                    if (x > max)
                    {
                        x = max;
                    }

                    return -x;
                default:
                    x = 0.2 * dayLength;
                    max = 0.05 * (temperature + 273);
                    if (x > max)
                    {
                        x = max;
                    }

                    return -x;
            }
        }
    }
}
