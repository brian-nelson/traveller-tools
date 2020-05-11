namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class MeanTemperatureGenerator
    {
        public static double Generate(
            double combinedLuminosity, 
            double orbitFactor, 
            double energyAbsorptionFactor, 
            double greenhouseFactor)
        {
            double meanTemperature = (combinedLuminosity * orbitFactor * energyAbsorptionFactor * greenhouseFactor) - 273;
            return meanTemperature;
        }
    }
}
