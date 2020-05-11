using System;
using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Enums;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Helpers
{
    public static class MassHelper
    {
        public static Mass ToKilograms(this Mass mass)
        {
            double massInKg;

            switch (mass.Units)
            {
                case MassUnits.Gram:
                    massInKg = mass.Value / 1000;
                    break;
                case MassUnits.Kilogram:
                    massInKg = mass.Value;
                    break;
                case MassUnits.EarthMass:
                    massInKg = mass.Value * SystemBodyConstants.EarthMass;
                    break;
                case MassUnits.StellarMass:
                    massInKg = mass.Value * SystemBodyConstants.SunMass;
                    break;
                default:
                    throw new Exception("Unknown distance units");
            }

            return new Mass()
            {
                Value = massInKg,
                Units = MassUnits.Kilogram
            };
        }

        public static Mass ToGrams(this Mass mass)
        {
            if (mass.Units == MassUnits.Gram)
            {
                return new Mass()
                {
                    Value = mass.Value,
                    Units = mass.Units
                };
            }

            Mass inKg = mass.ToKilograms();

            return new Mass()
            {
                Value = inKg.Value * 1000,
                Units = MassUnits.Gram
            };
        }

        public static Mass ToEarths(this Mass mass)
        {
            if (mass.Units == MassUnits.EarthMass)
            {
                return new Mass()
                {
                    Value = mass.Value,
                    Units = mass.Units
                };
            }

            Mass inKg = mass.ToKilograms();

            return new Mass()
            {
                Value = inKg.Value / SystemBodyConstants.EarthMass,
                Units = MassUnits.Kilogram
            };
        }

        public static Mass ToStellarMasses(this Mass mass)
        {
            if (mass.Units == MassUnits.StellarMass)
            {
                return new Mass()
                {
                    Value = mass.Value,
                    Units = mass.Units
                };
            }

            Mass inKg = mass.ToKilograms();

            return new Mass()
            {
                Value = inKg.Value / SystemBodyConstants.SunMass,
                Units = MassUnits.Kilogram
            };
        }

        public static Mass To(this Mass mass, MassUnits unit)
        {
            if (mass.Units == unit)
            {
                return new Mass()
                {
                    Value = mass.Value,
                    Units = mass.Units
                };
            }
            
            switch (unit)
            {
                case MassUnits.Gram:
                    return mass.ToGrams();
                case MassUnits.Kilogram:
                    return mass.ToKilograms();
                case MassUnits.EarthMass:
                    return mass.ToEarths();
                case MassUnits.StellarMass:
                    return mass.ToStellarMasses();
                default:
                    throw new Exception("Unknown distance units");
            }
        }
    }
}
