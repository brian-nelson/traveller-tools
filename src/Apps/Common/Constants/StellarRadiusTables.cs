namespace TravellerUtils.Libraries.Common.Constants
{
    public class StellarRadiusTables
    {
        //Adapted from http://www.atlasoftheuniverse.com/startype.html

        /* Stellar Mass -                  B0  B5  A0  A5  F0  F5   G0   G5   K0   K5   M0   M5  */
        public static double[] TableIa = { 30, 40, 60, 70, 80, 100, 120, 150, 200, 400, 450, 500 };

        /* Stellar Mass -                  B0  B5  A0  A5  F0  F5   G0   G5   K0   K5   M0   M5  */
        public static double[] TableIb = { 30, 40, 60, 70, 80, 100, 120, 150, 200, 400, 450, 500 };

        /*                                  B0  B5  A0  A5  F0  F5  G0 G5  K0  K5  M0  M5  */
        public static double[] TableII  = { 15, 8, 5, 5, 5, 5, 6, 10, 15, 25, 40, 80 };

        /*                                  B0  B5  A0  A5  F0  F5  G0 G5  K0  K5  M0  M5  */
        public static double[] TableIII = { 15, 8,  5,  5,  5 , 5,  6, 10, 15, 25, 40, 80 };

        /*                                 B0   B5   A0   A5   F0   F5   G0   G5    K0    K5    M0   M5  */
        public static double[] TableIV = { 7.4, 4.8, 2.4, 1.7, 1.5, 1.3, 1.1, 0.92, 0.85, 0.72, 0.6, 0.27 };

        /*                                B0   B5   A0   A5   F0   F5   G0   G5    K0    K5    M0   M5  */
        public static double[] TableV = { 7.4, 4.8, 2.4, 1.7, 1.5, 1.3, 1.1, 0.92, 0.85, 0.72, 0.6, 0.27 };

        /*                                B0   B5   A0   A5   F0   F5    G0    G5    K0    K5    M0    M5  */
        public static double[] TableD = { 0.3, 0.2, 0.2, 0.2, 0.2, 0.18, 0.17, 0.16, 0.16, 0.15, 0.11, 0.11 };


    }
}
