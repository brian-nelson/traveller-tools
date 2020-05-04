using TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Generators.StellarSystemAttributes
{
    public static class StarGenerator
    {
        public static Star Generate(int number = 1, Star primary = null)
        {
            Star output = new Star();

            if (number == 1)
            {
                output.Classification = StellarClassificationGenerator.Generate(false);
                output.LuminosityClass = StellarLuminosityClassGenerator.Generate(output.Classification);
                output.DecimalNotation = StellarDecimalNotationGenerator.Generate(output.Classification, output.LuminosityClass);
                output.Mass = StellarMassGenerator.Generate(output.Classification, output.DecimalNotation, output.LuminosityClass);
                output.Luminosity = StellarLuminosityGenerator.Generate(output.Classification, output.DecimalNotation, output.LuminosityClass);
            }
            else
            {
                output.Classification = StellarClassificationGenerator.Generate(true);
                output.LuminosityClass = StellarLuminosityClassGenerator.Generate(output.Classification, primary.LuminosityClass);
                output.DecimalNotation = StellarDecimalNotationGenerator.Generate(output.Classification, output.LuminosityClass);
                output.Mass = StellarMassGenerator.Generate(output.Classification, output.DecimalNotation, output.LuminosityClass);
                output.Luminosity = StellarLuminosityGenerator.Generate(output.Classification, output.DecimalNotation, output.LuminosityClass);
                output.Orbit = CompanionStarOrbitGenerator.Generate();
            }

            return output;
        }
    }
}
