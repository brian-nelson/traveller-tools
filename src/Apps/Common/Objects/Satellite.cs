using System;
using System.Collections.Generic;
using System.Text;
using TravellerUtils.Libraries.Common.Interfaces;

namespace TravellerUtils.Libraries.Common.Objects
{
    public class Satellite : ISystemBody
    {
        public short? Orbit { get; set; }
        public List<ISystemBody> OrbitingBodies { get; set; }
    }
}
