using System.Collections.Generic;
using TravellerUtils.Libraries.Common.Interfaces;

namespace TravellerUtils.Libraries.Common.Objects
{
    public class Planet : ISystemBody
    {
        public Planet()
        {
            OrbitingBodies = new List<ISystemBody>();
        }

        public short? Orbit { get; set; }
        public short Size { get; set; }
        public string Density { get; set; }
        public double OrbitalDistance { get; set; }
        public short Atmosphere { get; set; }
        public short Hydrographics { get; set; }

        public short MaxPopulation { get; set; }

        public double RotationPeriod { get; set; }
        public double OrbitFactor { get; set; }

        public short AtmosphereCode { get; set; }
        public double EnergyAbsorptionFactor { get; set; }

        public double GreenhouseFactor { get; set; }

        public double MeanTemperature { get; set; }

        public double AxialTilt { get; set; }

        public short AxialTiltEffect { get; set; }
        public double OrbitEccentricity { get; set; }
        public Seasons Seasons { get; set; }

        public double PlanetDiameter { get; set; }

        
        
        public List<ISystemBody> OrbitingBodies { get; set; }
    }
}
