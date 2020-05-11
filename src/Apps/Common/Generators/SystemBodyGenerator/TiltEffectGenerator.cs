using System;
using System.Collections.Generic;
using System.Text;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class TiltEffectGenerator
    {
        public static short Generate(double axialTilt)
        {
            /* k is tilt effect column */
            if (axialTilt <= 0.0)
            {
                return 0;
            }

            if (axialTilt < 6.0)
            {
                return 1;
            }

            if (axialTilt < 11.0)
            {
                return 2;
            }

            if (axialTilt < 16.0)
            {
                return 3;
            }

            if (axialTilt < 21.0)
            {
                return 4;
            }

            if (axialTilt < 26.0)
            {
                return 5;
            }

            if (axialTilt < 31.0)
            {
                return 6;
            }

            if (axialTilt < 36.0)
            {
                return 7;
            }

            if (axialTilt < 46.0)
            {
                return 8;
            }

            if (axialTilt < 61.0)
            {
                return 9;
            }

            if (axialTilt < 85.0)
            {
                return 10;
            }

            return 11;
        }
    }
}
