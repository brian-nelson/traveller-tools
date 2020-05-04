using TravellerUtils.Libraries.Common.Helpers;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class AxialTiltGenerator
    {
        public static double Generate()
        {
            int dieRoll = DieRoll.Roll2D6();

            switch (dieRoll)
            {
                case 2:
                case 3:
                    return -1.0 + DieRoll.Roll1D10();
                case 4:
                case 5:
                    return (9.0 + DieRoll.Roll1D10());
                case 6:
                case 7:
                    return (19.0 + DieRoll.Roll1D10());
                case 8:
                case 9:
                    return (20.0 + DieRoll.Roll1D10());
                case 10:
                case 11:
                    return (29.0 + DieRoll.Roll1D10());
                default:
                    dieRoll = DieRoll.Roll1D6();

                    switch (dieRoll)
                    {
                        case 1:
                        case 2:
                            return (49 + DieRoll.Roll1D10());
                        case 3:
                            return (59 + DieRoll.Roll1D10());
                        case 4:
                            return (69 + DieRoll.Roll1D10());
                        case 5:
                            return (79 + DieRoll.Roll1D10());
                        default:
                            return (90.00);
                    }
            }
        }
    }
}
