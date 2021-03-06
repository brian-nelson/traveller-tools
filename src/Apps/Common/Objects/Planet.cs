﻿using System.Collections.Generic;
using TravellerUtils.Libraries.Common.Interfaces;

namespace TravellerUtils.Libraries.Common.Objects
{
    public class Planet : IStellarOrbitingBody, IEnvironmental
    {
        public Planet()
        {
            OrbitingBodies = new Dictionary<short, IOrbitingBody>();
        }

        //ISystemBody
        public short Size { get; set; }
        public string Density { get; set; }
        public Mass Mass { get; set; }
        public Distance Diameter { get; set; }
        public Dictionary<short, IOrbitingBody> OrbitingBodies { get; set; }

        //IOrbitingBody
        public short OrbitNumber { get; set; }
        public double OrbitEccentricity { get; set; }
        public Distance OrbitalDistance { get; set; }
        public double OrbitalPeriod { get; set; }
        public double RotationPeriod { get; set; }
        public double AxialTilt { get; set; }
        public short AxialTiltEffect { get; set; }

        //IStellarOrbitingBody
        public string OrbitType { get; set; }
        public string OrbitOccupiedType { get; set; }

        public short MaxPopulation { get; set; }

        //IEnvironmental
        public short Atmosphere { get; set; }
        public short Hydrographics { get; set; }
        public double OrbitFactor { get; set; }
        public short AtmosphereCode { get; set; }
        public double EnergyAbsorptionFactor { get; set; }
        public double GreenhouseFactor { get; set; }
        public double MeanTemperature { get; set; }
        public Seasons Seasons { get; set; }

    }
}
