using System.Collections.Generic;
using TravellerUtils.Libraries.Common.Interfaces;

namespace TravellerUtils.Libraries.Common.Objects
{
    public class GasGiant :  ISystemBody
    {
        public GasGiant()
        {
            OrbitingBodies = new List<ISystemBody>();
        }

        public short? Orbit { get; set; }
        public double Diameter { get; set; }
        public double OrbitalDistance { get; set; }
        
        public string Description { get; set; }


        public List<ISystemBody> OrbitingBodies { get; set; }


    }
}
