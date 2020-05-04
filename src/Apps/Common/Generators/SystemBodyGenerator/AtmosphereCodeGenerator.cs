namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class AtmosphereCodeGenerator
    {
        public static short Generate(short atmosphere)
        {
            short atmosphereCode;

            if (atmosphere < 4)
            {
                atmosphereCode = 0;
            }
            else if (atmosphere < 10)
            {
                atmosphereCode = 1;
            }
            else if (atmosphere < 16)
            {
                atmosphereCode = 2;
            }
            else
            {
                atmosphereCode = 3;
            }

            return atmosphereCode;
        }
    }
}
