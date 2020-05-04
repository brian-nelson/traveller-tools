using System;
using TravellerUtils.Libraries.Common.Helpers;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class OrbitRangeGenerator
    {
        public static double Generate(short orbitNumber)
        {
            double r;

            switch (orbitNumber)
            {
                case 0: r = 0.1 + PerturbHelper.Change(0.1); break; /* 0.2 */
                case 1: r = 0.3 + PerturbHelper.Change(0.1); break; /* 0.4 */
                case 2: r = 0.6 + PerturbHelper.Change(0.1); break; /* 0.7 */
                case 3: r = 0.8 + PerturbHelper.Change(0.2); break; /* 1.0 */
                case 4: r = 1.2 + PerturbHelper.Change(0.4); break; /* 1.6 */
                case 5: r = 2.0 + PerturbHelper.Change(0.8); break; /* 2.8 */
                case 6: r = 3.6 + PerturbHelper.Change(1.6); break; /* 5.2 */
                case 7: r = 6.8 + PerturbHelper.Change(3.2); break; /* 10.0 */
                case 8: r = 13.2 + PerturbHelper.Change(6.4); break; /* 19.6 */
                case 9: r = 26.0 + PerturbHelper.Change(12.8); break; /* 38.8 */
                case 10: r = 51.6 + PerturbHelper.Change(25.6); break; /* 77.2 */
                case 11: r = 102.8 + PerturbHelper.Change(51.2); break; /* 154.0 */
                case 12: r = 205.2 + PerturbHelper.Change(102.4); break; /* 307.6 */
                case 13: r = 410.0 + PerturbHelper.Change(204.8); break; /* 614.8 */
                case 14: r = 819.6 + PerturbHelper.Change(409.6); break; /* 1229.2 */
                case 15: r = 1638.8 + PerturbHelper.Change(819.2); break; /* 2548.0 */
                case 16: r = 3277.2 + PerturbHelper.Change(1638.4); break; /* 4915.6 */
                case 17: r = 6554.0 + PerturbHelper.Change(3276.8); break; /* 9830.8 */
                case 18: r = 13107.6 + PerturbHelper.Change(6553.6); break; /* 19661.2 */
                case 19: r = 26214.8 + PerturbHelper.Change(13107.2); break; /* 39322.0 */
                default:
                    throw new Exception("Unexpected orbit");
            }

            return r;
        }
    }
}
