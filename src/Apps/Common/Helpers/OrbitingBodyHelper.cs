using System.Linq;
using TravellerUtils.Libraries.Common.Interfaces;

namespace TravellerUtils.Libraries.Common.Helpers
{
    public static class OrbitingBodyHelper
    {
        public static IOrbitingBody InnerOrbitingBody(this ISystemBody body, int orbitNumber)
        {
            var keys = body.OrbitingBodies.Keys.OrderByDescending(k=>k);

            foreach (var orbit in keys)
            {
                if (orbitNumber > orbit)
                {
                    return body.OrbitingBodies[orbit];
                }
            }

            return null;
        }

        public static IOrbitingBody OuterOrbitingBody(this ISystemBody body, int orbitNumber)
        {
            var keys = body.OrbitingBodies.Keys.OrderBy(k => k);

            foreach (var orbit in keys)
            {
                if (orbitNumber < orbit)
                {
                    return body.OrbitingBodies[orbit];
                }
            }

            return null;
        }
    }
}
