using System;
using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Generators.SatelliteGenerators;
using TravellerUtils.Libraries.Common.Helpers;
using TravellerUtils.Libraries.Common.Interfaces;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class SatelliteGenerator
    {
        public static IOrbitingBody Generate(IStar parentStar, IStellarOrbitingBody parentBody)
        {
            Moon moon = new Moon();

            //Body Details
            moon.Size = SatelliteSizeGenerator.Generate(parentBody.Size);
            moon.Density = DensityGenerator.Generate(parentBody.OrbitType);
            moon.Diameter = PlanetDiameterGenerator.Generate(OccupiedTypes.World, moon.Size);
            moon.Mass = PlanetMassGenerator.Generate(moon.Diameter, moon.Density);

            //Orbital
            moon.OrbitalDistance = (parentBody.Diameter / 2) * SatelliteOrbitGenerator.Generate();
            moon.OrbitalPeriod = OrbitalPeriodGenerator.Generate(parentBody, moon);
            moon.OrbitFactor = OrbitFactorGenerator.Generate(parentBody);
            moon.OrbitEccentricity = OrbitalEccentricityGenerator.Generate();
            moon.RotationPeriod = (4 * (DieRoll.Roll2D6() - 2)) + 5;
            moon.AxialTilt = AxialTiltGenerator.Generate();
            moon.AxialTiltEffect = TiltEffectGenerator.Generate(moon.AxialTilt);
            
            moon.Atmosphere = AtmosphereGenerator.Generate(parentBody.OrbitType, parentBody.Size);
            moon.AtmosphereCode = AtmosphereCodeGenerator.Generate(moon.Atmosphere); 
            moon.Hydrographics = HydrographicsGenerator.Generate(parentBody.OrbitType, moon.Size, moon.Atmosphere);
            
            int maxPopulation = MaxPopulationGenerator.Generate(parentBody.OrbitNumber, parentBody.OrbitType, moon.Size,
                moon.Atmosphere, moon.Hydrographics, parentStar.HabitableZone);

            double energyAbsorptionFactor = EnergyAbsorptionGenerator.Generate(parentBody.OrbitType, moon.Hydrographics, moon.AtmosphereCode);




            return null;
        }


        

        
    }
}
