namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class GaiaFactorGenerator
    {
        public static double Generate(double luminosity, double orbitFactor, double greenhouseFactor, double energyAbsorptionFactor) 
        {
            /* Calculate Ideal E */
            double ideal;
            double gaiaFactor;

            ideal = 288.00 / luminosity / orbitFactor / greenhouseFactor;

            gaiaFactor = (ideal - energyAbsorptionFactor) / 2;

            if (gaiaFactor > 0.0)
            {
                if (gaiaFactor > 0.1)
                {
                    gaiaFactor = 0.1;
                }
            }
            else
            {
                if (gaiaFactor < -0.1)
                {
                    gaiaFactor = -0.1;
                }
            }

            return (energyAbsorptionFactor + gaiaFactor);
        }
    }
}
