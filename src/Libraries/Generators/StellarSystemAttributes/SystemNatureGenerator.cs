﻿using Common.Constants;
using Common.Helpers;

namespace Generators.StellarSystemAttributes
{
    public static class SystemNatureGenerator
    {
        public static string Generate()
        {
            int roll = DieRoll.Roll2D6();

            if (roll < 8)
            {
                return SystemNature.Solo;
            }

            if (roll == 12)
            {
                return SystemNature.Trinary;
            }

            return SystemNature.Binary;
        }


    }
}
