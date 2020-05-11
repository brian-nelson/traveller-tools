using System.Collections.Generic;
using TravellerUtils.Libraries.Common.Interfaces;

namespace TravellerUtils.Libraries.Common.Objects
{
    public class StellarSystem
    {
        public StellarSystem()
        {
            Stars = new List<IStar>();
        }
        public int X { get; set; }
        public int Y { get; set; }

        public string SystemNature { get; set; }

        public string Habitability { get; set; }

        public string Port { get; set; }
        public byte Population { get; set; }
        public byte TechLevel { get; set; }
        public byte Government { get; set; }

        public double CombinedLuminosity { get; set; }
        
        public List<IStar> Stars { get; set; }
    }
}
