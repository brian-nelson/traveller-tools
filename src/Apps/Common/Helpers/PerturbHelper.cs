using System;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Helpers
{
    public static class PerturbHelper
    {
        private static Random _random = new Random();

        public static double Change(double original)
        {
            double x = DieRoll.Roll1D10() * 10 + DieRoll.Roll1D10();
            var y = x / 100;

            if (DieRoll.Roll1D6() < 4) /* reduce value */
            {
                return (original * y);
            }

            return (original * (1.0 + y));
        }

        public static double Change(double min, double max)
        {
            double output = min + (max - min) * _random.NextDouble();
            return output;
        }

        public static Distance Change(Distance min, Distance max)
        {
            if (min.Units != max.Units)
            {
                throw new Exception("Units must match");
            }

            double value = Change(min.Value, max.Value);

            return new Distance()
            {
                Value = value,
                Units = min.Units
            };
        }
    }
}
