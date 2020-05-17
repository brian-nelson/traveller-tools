﻿using System.Collections.Generic;
using TravellerUtils.Libraries.Common.Interfaces;

namespace TravellerUtils.Libraries.Common.Objects
{
    public class AsteroidBelt : IOrbitingBody
    {
        public AsteroidBelt()
        {
            //Created, but won't be used for asteroid belt
            OrbitingBodies = new Dictionary<short, IOrbitingBody>();
        }

        public short Size { get; set; }
        public string Density { get; set; }
        public Mass Mass { get; set; }
        public Distance Diameter { get; set; }
        public Dictionary<short, IOrbitingBody> OrbitingBodies { get; set; }


        public short OrbitNumber { get; set; }
        public double OrbitEccentricity { get; set; }
        public Distance OrbitalDistance { get; set; }
        public double OrbitalPeriod { get; set; }
        public double RotationPeriod { get; set; }
        public double AxialTilt { get; set; }
        public short AxialTiltEffect { get; set; }
    }
}
