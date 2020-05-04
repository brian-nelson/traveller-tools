using TravellerUtils.Libraries.Common.Enums;
using TravellerUtils.Libraries.Common.Helpers;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Generators
{
    public static class SubsectorGenerator
    {
        public static SubSector Generate(SubsectorDensity density = SubsectorDensity.Standard)
        {
            SubSector output = new SubSector();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (IsSystemPresent(density))
                    {
                        var stellarSystem = StellarSystemGenerator.Generate(i, j);
                    }
                }
            }

            return output;
        }

        private static bool IsSystemPresent(SubsectorDensity density)
        {
            int roll;

            switch (density)
            {
                case SubsectorDensity.Rift:
                    roll = DieRoll.Roll2D6();

                    if (roll == 12)
                    {
                        return true;
                    }

                    break;
                case SubsectorDensity.Sparse:
                    roll = DieRoll.Roll1D6();

                    if (roll == 6)
                    {
                        return true;
                    }

                    break;
                case SubsectorDensity.Scattered:
                    roll = DieRoll.Roll1D6();

                    if (roll >= 5)
                    {
                        return true;
                    }

                    break;
                case SubsectorDensity.Standard:
                    roll = DieRoll.Roll1D6();

                    if (roll >= 4)
                    {
                        return true;
                    }

                    break;
                case SubsectorDensity.Dense:
                    roll = DieRoll.Roll1D6();

                    if (roll >= 3)
                    {
                        return true;
                    }

                    break;
            }

            return false;
        }
    }
}
