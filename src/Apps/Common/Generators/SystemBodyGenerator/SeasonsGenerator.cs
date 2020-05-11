using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class SeasonsGenerator
    {
        public static Seasons Generate(int planetSize, double axialTilt, int axialTiltEffect, double orbitFactorEccentricity, 
            double meanTemperature, double luminosity, Distance orbitalDistance, double rotationPeriod, short atmosphere)
        {
            Seasons output = new Seasons
            {
                DaytimeTemperatureDelta = TimeGenerator.GenerateDayTime(atmosphere, rotationPeriod, luminosity, orbitalDistance, meanTemperature),
                NighttimeTemperatureDelta = TimeGenerator.GenerateNightTime(atmosphere, rotationPeriod, meanTemperature)
            };

            for (int i = 0; i < 22; ++i)
            {
                double x;

                x = i % 2 == 0 ? output.DaytimeTemperatureDelta : output.NighttimeTemperatureDelta;

                double summer = meanTemperature 
                                + PlanetTables.LatitudeMods[i / 2, planetSize] 
                                + (orbitFactorEccentricity * 30) 
                                + ((0.6 * axialTilt) * PlanetTables.AxialTiltEffects[i / 2, axialTiltEffect]) 
                                + x; 

                double fall = meanTemperature 
                              + PlanetTables.LatitudeMods[i / 2, planetSize] 
                              + x;

                double winter = meanTemperature 
                              + PlanetTables.LatitudeMods[i / 2, planetSize] 
                              - (orbitFactorEccentricity * 30)
                              - (axialTilt * PlanetTables.AxialTiltEffects[i / 2, axialTiltEffect]) 
                              + x;

                output.Summer.Add(summer);
                output.Fall.Add(fall);
                output.Winter.Add(winter);
            }

            return output;
        }
    }
}
