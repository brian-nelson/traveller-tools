using System.Collections.Generic;

namespace TravellerUtils.Libraries.Common.Objects
{
    public class StellarSystem
    {
        public StellarSystem()
        {
            Stars = new List<Star>();
            SystemBodies = new List<SystemBody>();
        }
        public int X { get; set; }
        public int Y { get; set; }

        public string SystemNature { get; set; }

        public string Habitability { get; set; }

        public string Port { get; set; }
        public byte Population { get; set; }
        public byte TechLevel { get; set; }
        public byte Government { get; set; }
        
        public List<Star> Stars { get; set; }

        public List<SystemBody> SystemBodies { get; set; }

    }
}
