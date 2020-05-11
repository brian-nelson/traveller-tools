using System;
using System.Collections.Generic;
using System.Text;
using TravellerUtils.Libraries.Common.Interfaces;

namespace TravellerUtils.Libraries.Common.Objects
{
    public class CompanionStar : IStar, IOrbitingBody
    {
        //ISystemBody
        public short Size { get; set; }
        public string Density { get; set; }
        public Mass Mass { get; set; }
        public Distance Diameter { get; set; }
        public List<IOrbitingBody> OrbitingBodies { get; set; }

        //IStar
        public string Classification { get; set; }
        public string LuminosityClass { get; set; }
        public string DecimalNotation { get; set; }
        public double Luminosity { get; set; }
        public short HabitableZone { get; set; }

        //IOrbitingBody
        public short OrbitNumber { get; set; }
        public double OrbitEccentricity { get; set; }
        public Distance OrbitalDistance { get; set; }
        public double OrbitalPeriod { get; set; }
        public double RotationPeriod { get; set; }
        public double AxialTilt { get; set; }
        public short AxialTiltEffect { get; set; }
    }
}
