using System;
using System.Collections.Generic;
using System.Text;
using TravellerUtils.Libraries.Common.Helpers;

namespace TravellerUtils.Libraries.Common.Generators.SatelliteGenerators
{
    public static class SatelliteOrbitGenerator
    {
        public static int Generate()
        {
            int dieRoll = DieRoll.Roll2D6();

            if (dieRoll < 8)
            {
                switch (DieRoll.Roll2D6())
                {
                    case 2:
                        {
                            return 3;
                        }
                    case 3:
                        {
                            return 4;
                        }
                    case 4:
                        {
                            return 5;
                        }
                    case 5:
                        {
                            return 6;
                        }
                    case 6:
                        {
                            return 7;
                        }
                    case 7:
                        {
                            return 8;
                        }
                    case 8:
                        {
                            return 9;
                        }
                    case 9:
                        {
                            return 10;
                        }
                    case 10:
                        {
                            return 11;
                        }
                    case 11:
                        {
                            return 12;
                        }
                    case 12:
                        {
                            return 12;
                        }
                }
            }
            else if (dieRoll < 12)
            {
                switch (DieRoll.Roll2D6())
                {
                    case 2:
                        {
                            return 15;
                        }
                    case 3:
                        {
                            return 20;
                        }
                    case 4:
                        {
                            return 25;
                        }
                    case 5:
                        {
                            return 30;
                        }
                    case 6:
                        {
                            return 35;
                        }
                    case 7:
                        {
                            return 40;
                        }
                    case 8:
                        {
                            return 45;
                        }
                    case 9:
                        {
                            return 50;
                        }
                    case 10:
                        {
                            return 55;
                        }
                    case 11:
                        {
                            return 60;
                        }
                    case 12:
                        {
                            return 65;
                        }
                }
            }
            else
            {
                switch (DieRoll.Roll2D6())
                {
                    case 2:
                        {
                            return 75;
                        }
                    case 3:
                        {
                            return 100;
                        }
                    case 4:
                        {
                            return 125;
                        }
                    case 5:
                        {
                            return 150;
                        }
                    case 6:
                        {
                            return 175;
                        }
                    case 7:
                        {
                            return 200;
                        }
                    case 8:
                        {
                            return 225;
                        }
                    case 9:
                        {
                            return 250;
                        }
                    case 10:
                        {
                            return 275;
                        }
                    case 11:
                        {
                            return 300;
                        }
                    case 12:
                        {
                            return 325;
                        }
                }
            }

            return 12;
        }
    }
}
