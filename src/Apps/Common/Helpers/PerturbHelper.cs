namespace TravellerUtils.Libraries.Common.Helpers
{
    public static class PerturbHelper
    {
        public static double Change(double original)
        {
            double x = DieRoll.Roll1D10() * 10 + DieRoll.Roll1D10();
            var y = x / 100;

            if (DieRoll.Roll1D6() < 4) /* reduce value */
            {
                return (original * y);
            }

            return (original * (1.0 + y));
        }
    }
}
