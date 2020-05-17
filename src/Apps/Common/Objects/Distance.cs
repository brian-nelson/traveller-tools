using TravellerUtils.Libraries.Common.Enums;
using TravellerUtils.Libraries.Common.Helpers;

namespace TravellerUtils.Libraries.Common.Objects
{
    public struct Distance
    {
        public double Value { get; set; }
        public DistanceUnits Units { get; set; }

        public Distance(double value, DistanceUnits units)
        {
            Value = value;
            Units = units;
        }
        
        public static Distance operator +(Distance a, Distance b)
        {
            Distance tempB = b.To(a.Units);

            Distance output = new Distance
            {
                Value = a.Value + tempB.Value, 
                Units = a.Units
            };

            return output;
        }

        public static Distance operator -(Distance a, Distance b)
        {
            Distance tempB = b.To(a.Units);

            Distance output = new Distance
            {
                Value = a.Value - tempB.Value,
                Units = a.Units
            };

            return output;
        }

        public static bool operator >(Distance a, Distance b)
        {
            Distance tempB = b.To(a.Units);

            return a.Value > tempB.Value;
        }

        public static bool operator <(Distance a, Distance b)
        {
            Distance tempB = b.To(a.Units);

            return a.Value < tempB.Value;
        }

        public static Distance operator /(Distance a, double divisor)
        {
            Distance output = new Distance
            {
                Value = a.Value / divisor,
                Units = a.Units
            };

            return output;
        }

        public static Distance operator *(Distance a, double multiplier)
        {
            Distance output = new Distance
            {
                Value = a.Value * multiplier,
                Units = a.Units
            };

            return output;
        }
    }
}
