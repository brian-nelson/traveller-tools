﻿using TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator;
using TravellerUtils.Libraries.Common.Interfaces;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Generators.StellarSystemAttributes
{
    public static class StarGenerator
    {
        public static IStar Generate(int number = 1, IStar primary = null)
        {
            IStar output;

            if (number == 1)
            {
                output = new Star();
                output.Classification = StellarClassificationGenerator.Generate(false);
                output.LuminosityClass = StellarLuminosityClassGenerator.Generate(output.Classification);
                output.DecimalNotation = StellarDecimalNotationGenerator.Generate(output.Classification, output.LuminosityClass);
                output.Mass = StellarMassGenerator.Generate(output.Classification, output.DecimalNotation, output.LuminosityClass);
                output.Luminosity = StellarLuminosityGenerator.Generate(output.Classification, output.DecimalNotation, output.LuminosityClass);
                output.Diameter = StellarRadiusGenerator.Generate(output.Classification, output.DecimalNotation, output.LuminosityClass) * 2;
            }
            else
            {
                output = new CompanionStar();
                
                output.Classification = StellarClassificationGenerator.Generate(true);
                output.LuminosityClass = StellarLuminosityClassGenerator.Generate(output.Classification, primary.LuminosityClass);
                output.DecimalNotation = StellarDecimalNotationGenerator.Generate(output.Classification, output.LuminosityClass);
                output.Mass = StellarMassGenerator.Generate(output.Classification, output.DecimalNotation, output.LuminosityClass);
                output.Luminosity = StellarLuminosityGenerator.Generate(output.Classification, output.DecimalNotation, output.LuminosityClass);
                output.Diameter = StellarRadiusGenerator.Generate(output.Classification, output.DecimalNotation, output.LuminosityClass) * 2;

                var companion = (CompanionStar)output;
                companion.OrbitNumber = CompanionStarOrbitGenerator.Generate();

                if (primary.OrbitingBodies.ContainsKey(companion.OrbitNumber))
                {
                    companion.OrbitNumber += 1;
                    primary.OrbitingBodies.Add(companion.OrbitNumber, companion);
                }
            }

            return output;
        }
    }
}
