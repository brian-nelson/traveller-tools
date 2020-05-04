using System.Collections.Generic;
using TravellerUtils.Libraries.Common.Interfaces;

namespace TravellerUtils.Libraries.Common.Objects
{
    public class Star : ISystemBody
    {
        public Star()
        {
            OrbitingBodies = new List<ISystemBody>();
        }

        public string Classification { get; set; }
        public string LuminosityClass { get; set; }
        public string DecimalNotation { get; set; }
        public double Mass { get; set; }
        public double Luminosity { get; set; }
        public short? Orbit { get; set; }
        public int HabitableZone { get; set; }

        public List<ISystemBody> OrbitingBodies { get; set; }
    }
}
