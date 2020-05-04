using System;
using Common.Constants;
using Common.Objects;
using Generators.StellarSystemAttributes;

namespace Generators
{
    public static class StellarSystemGenerator
    {
        public static StellarSystem Generate(int x, int y)
        {
            var output = new StellarSystem();
            output.X = x;
            output.Y = y;
            output.SystemNature = SystemNatureGenerator.Generate();
            
            //Add Primary
            output.Stars.Add(StarGenerator.Generate(1));
            
            //Add Secondary Star
            if (output.SystemNature == SystemNature.Binary
                || output.SystemNature == SystemNature.Trinary)
            {
                output.Stars.Add(StarGenerator.Generate(2));
            }

            //Add Third Star
            if (output.SystemNature == SystemNature.Trinary)
            {
                output.Stars.Add(StarGenerator.Generate(3));
            }
            



            return output;
        }

    }
}
