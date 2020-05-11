using System;
using TravellerUtils.Libraries.Common.Enums;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Helpers
{
    public static class DistanceHelper
    {
        public static Distance ToMeters(this Distance distance)
        {
            double lengthInMeters;

            switch (distance.Units)
            {
                case DistanceUnits.Meter:
                    lengthInMeters = distance.Value;
                    break;
                case DistanceUnits.Kilometer:
                    lengthInMeters = distance.Value * 1000.0;
                    break;
                case DistanceUnits.Feet:
                    lengthInMeters = distance.Value * 0.3048;
                    break;
                case DistanceUnits.Miles:
                    lengthInMeters = distance.Value * 1609.34;
                    break;
                case DistanceUnits.AstronomicalUnit:
                    lengthInMeters = distance.Value * 1.496e+11;
                    break;
                case DistanceUnits.LightYear:
                    lengthInMeters = distance.Value * 9.461e+15;
                    break;
                case DistanceUnits.Parsec:
                    lengthInMeters = distance.Value * 3.086e+16;
                    break;
                default:
                    throw new Exception("Unknown distance units");
            }

            return new Distance()
            {
                Value = lengthInMeters,
                Units = DistanceUnits.Meter
            };
        }

        public static Distance ToKilometers(this Distance distance)
        {
            if (distance.Units == DistanceUnits.Kilometer)
            {
                return new Distance()
                {
                    Value = distance.Value,
                    Units = distance.Units
                };
            }

            Distance inMeters = distance.ToMeters();

            return new Distance()
            {
                Value = inMeters.Value / 1000,
                Units = DistanceUnits.Kilometer
            };
        }

        public static Distance ToFeet(this Distance distance)
        {
            if (distance.Units == DistanceUnits.Feet)
            {
                return new Distance()
                {
                    Value = distance.Value,
                    Units = distance.Units
                };
            }

            Distance inMeters = distance.ToMeters();

            return new Distance()
            {
                Value = inMeters.Value / 0.3048,
                Units = DistanceUnits.Feet
            };
        }

        public static Distance ToMiles(this Distance distance)
        {
            if (distance.Units == DistanceUnits.Miles)
            {
                return new Distance()
                {
                    Value = distance.Value,
                    Units = distance.Units
                };
            }

            Distance inMeters = distance.ToMeters();

            return new Distance()
            {
                Value = inMeters.Value / 1609.34,
                Units = DistanceUnits.Miles
            };
        }

        public static Distance ToAstronomicalUnits(this Distance distance)
        {
            if (distance.Units == DistanceUnits.AstronomicalUnit)
            {
                return new Distance()
                {
                    Value = distance.Value,
                    Units = distance.Units
                };
            }

            Distance inMeters = distance.ToMeters();

            return new Distance()
            {
                Value = inMeters.Value / 1.496e+11,
                Units = DistanceUnits.Miles
            };
        }

        public static Distance ToLightYear(this Distance distance)
        {
            if (distance.Units == DistanceUnits.LightYear)
            {
                return new Distance()
                {
                    Value = distance.Value,
                    Units = distance.Units
                };
            }

            Distance inMeters = distance.ToMeters();

            return new Distance()
            {
                Value = inMeters.Value / 9.461e+15,
                Units = DistanceUnits.Miles
            };
        }

        public static Distance ToParsec(this Distance distance)
        {
            if (distance.Units == DistanceUnits.Parsec)
            {
                return new Distance()
                {
                    Value = distance.Value,
                    Units = distance.Units
                };
            }

            Distance inMeters = distance.ToMeters();

            return new Distance()
            {
                Value = inMeters.Value / 3.086e+16,
                Units = DistanceUnits.Miles
            };
        }

        public static Distance To(this Distance distance, DistanceUnits unit)
        {
            if (distance.Units.Equals(unit))
            {
                return new Distance()
                {
                    Value = distance.Value,
                    Units = distance.Units
                };
            }

            switch (distance.Units)
            {
                case DistanceUnits.Meter:
                    return distance.ToMeters();
                case DistanceUnits.Kilometer:
                    return distance.ToKilometers();
                case DistanceUnits.Feet:
                    return distance.ToFeet();
                case DistanceUnits.Miles:
                    return distance.ToMiles();
                case DistanceUnits.AstronomicalUnit:
                    return distance.ToAstronomicalUnits();
                case DistanceUnits.LightYear:
                    return distance.ToLightYear();
                case DistanceUnits.Parsec:
                    return distance.ToParsec();
                default:
                    throw new Exception("Unknown distance units");
            }
        }
    }
}
