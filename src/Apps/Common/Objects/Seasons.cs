using System.Collections.Generic;

namespace TravellerUtils.Libraries.Common.Objects
{
    public class Seasons
    {
        public Seasons()
        {
            Summer = new List<double>();
            Winter = new List<double>();
            Fall = new List<double>();
        }

        public double DaytimeTemperatureDelta { get; set; }
        public double NighttimeTemperatureDelta { get; set; }

        public List<double> Summer { get; set; }
        public List<double> Winter { get; set; }
        public List<double> Fall { get; set; }
    }
}
