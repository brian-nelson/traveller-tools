using System;
using System.Collections.Generic;
using System.Threading;
using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Generators.StellarSystemAttributes;
using TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator;
using TravellerUtils.Libraries.Common.Interfaces;
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
            IStar primary = StarGenerator.Generate(1);
            output.Stars.Add(primary);
            output.CombinedLuminosity = primary.Luminosity;
            
            //Add Secondary Star
            if (output.SystemNature == SystemNature.Binary
                || output.SystemNature == SystemNature.Trinary)
            {
                IStar star = StarGenerator.Generate(2, output.Stars[0]);
                output.Stars.Add(star);
            }

            //Add Third Star
            if (output.SystemNature == SystemNature.Trinary)
            {
                output.Stars.Add(StarGenerator.Generate(3, output.Stars[0]));
            }
            
            //Generate primary start bodies
            var systemBodies = SystemBodiesGenerator.Generate(output, 0);


            return output;
        }

    }
}
