using TravellerUtils.Libraries.Common.Enums;
using TravellerUtils.Libraries.Common.Helpers;

namespace TravellerUtils.Libraries.Common.Objects
{
    public struct Mass
    {
        public double Value { get; set; }
        public MassUnits Units { get; set; }

        public static Mass operator +(Mass a, Mass b)
        {
            Mass tempB = b.To(a.Units);

            Mass output = new Mass
            {
                Value = a.Value + tempB.Value,
                Units = a.Units
            };

            return output;
        }

        public static Mass operator -(Mass a, Mass b)
        {
            Mass tempB = b.To(a.Units);

            Mass output = new Mass
            {
                Value = a.Value - tempB.Value,
                Units = a.Units
            };

            return output;
        }
    }
}
