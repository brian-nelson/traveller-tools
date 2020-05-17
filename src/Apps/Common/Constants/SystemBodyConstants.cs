using System;
using System.Xml;

namespace TravellerUtils.Libraries.Common.Constants
{
    public static class SystemBodyConstants
    {
        public const double GravitationalConstant = 6.673E-11;                           // Nm^2/kg^2
        public const double EarthGravity = 9.8;                                          // m/s^2
        public const double EarthRadius = 6371;                                          // km
        public static double EarthVolume = (4 / 3) * Math.PI * Math.Pow(EarthRadius, 3); // m^3
        public const double EarthMass = 5.972E24;                                        // kg

        public const double SunMass = 1.989E30;                                          // kg
        public const double SunRadius = 695000;                                          // km

    }
}
