using System;
using TravellerUtils.Libraries.Common.Enums;

namespace TravellerUtils.Libraries.Common.Helpers
{
    public static class DieRoll
    {
        private static readonly Random m_Rand = new Random();
        
        public static short Roll(RollTypes roleType)
        {
            switch (roleType)
            {
                case RollTypes.Roll1D6:
                    return Roll1D6();
                case RollTypes.Roll2D6:
                    return Roll2D6();
                case RollTypes.Roll1D6X10Plus1D6:
                    return Roll1D6X10Plus1D6();
                default:
                    throw new Exception("Unknown roll type");
            }
        }

        public static short Roll1D6()
        {
            return (short)m_Rand.Next(1, 6);
        }

        public static short Roll1D10()
        {
            return (short)m_Rand.Next(1, 10);
        }

        public static short Roll2D6()
        {
            return (short)(Roll1D6() + Roll1D6());
        }

        public static short Roll3D6()
        {
            return (short)(Roll1D6() + Roll1D6() + Roll1D6());
        }

        public static short Roll1D6X10Plus1D6()
        {
            return (short)(Roll1D6() * 10 + Roll1D6());
        }

    }
}
