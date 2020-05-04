using System.Collections.Generic;
using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Generators.StellarSystemAttributes;
using TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Generators
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
                output.Stars.Add(StarGenerator.Generate(2, output.Stars[0]));
            }

            //Add Third Star
            if (output.SystemNature == SystemNature.Trinary)
            {
                output.Stars.Add(StarGenerator.Generate(3, output.Stars[0]));
            }
            
            //Generate primary start bodies
            var systemBodies = SystemBodiesGenerator.Generate(output.Stars, 0);


            return output;
        }

    }
}
