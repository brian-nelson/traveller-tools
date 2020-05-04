using System;
using Common.Constants;
using Common.Helpers;

namespace Generators.StellarSystemAttributes
{
    public static class StellarClassificationGenerator
    {
        public static string Generate(bool noRareStars = false)
        {
            int dieRoll;

            if (!noRareStars)
            {
                dieRoll = DieRoll.Roll3D6();

                if (dieRoll == 3) return (StellarClassifications.O);
                if (dieRoll == 4) return (StellarClassifications.B);
            }

            dieRoll = DieRoll.Roll2D6();
            
            switch (dieRoll)
            {
                case 2: return (StellarClassifications.A); 
                case 3: return (StellarClassifications.M); 
                case 4: return (StellarClassifications.M); 
                case 5: return (StellarClassifications.M);
                case 6: return (StellarClassifications.M); 
                case 7: return (StellarClassifications.M); 
                case 8: return (StellarClassifications.K); 
                case 9: return (StellarClassifications.G);
                case 10: return (StellarClassifications.G);
                case 11: return (StellarClassifications.F);
                case 12: return (StellarClassifications.F);
            }

            throw new Exception("Invalid type");
        }
    }
}
