using System.Collections.Generic;
using TravellerUtils.Libraries.Common.Interfaces;

namespace TravellerUtils.Libraries.Common.Objects
{
    public class Star : IStar
    {
        public Star()
        {
            OrbitingBodies = new Dictionary<short, IOrbitingBody>();
        }

        //ISystemBody
        public short Size { get; set; }
        public string Density { get; set; }
        public Mass Mass { get; set; }
        public Distance Diameter { get; set; }
        public Dictionary<short, IOrbitingBody> OrbitingBodies { get; set; }

        //IStar
        public string Classification { get; set; }
        public string LuminosityClass { get; set; }
        public string DecimalNotation { get; set; }
        public double Luminosity { get; set; }
        public short HabitableZone { get; set; }

        public short? Orbit { get; set; }

    }
}
