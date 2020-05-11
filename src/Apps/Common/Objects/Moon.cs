using System.Collections.Generic;
using TravellerUtils.Libraries.Common.Interfaces;

namespace TravellerUtils.Libraries.Common.Objects
{
    public class Moon : IOrbitingBody, IEnvironmental
    {
        //IStellarBody
        public short Size { get; set; }
        public string Density { get; set; }
        public Mass Mass { get; set; }
        public Distance Diameter { get; set; }
        public List<IOrbitingBody> OrbitingBodies { get; set; }

        //IOrbitingBody
        public short OrbitNumber { get; set; }
        public double OrbitEccentricity { get; set; }
        public Distance OrbitalDistance { get; set; }
        public double OrbitalPeriod { get; set; }
        public double OrbitFactor { get; set; }
                public double AxialTilt { get; set; }
        public short AxialTiltEffect { get; set; }


        //IEnvironmental
        public short Atmosphere { get; set; }
        public short Hydrographics { get; set; }
        public double RotationPeriod { get; set; }
        public short AtmosphereCode { get; set; }
        public double EnergyAbsorptionFactor { get; set; }
        public double GreenhouseFactor { get; set; }
        public double MeanTemperature { get; set; }

    }
}
