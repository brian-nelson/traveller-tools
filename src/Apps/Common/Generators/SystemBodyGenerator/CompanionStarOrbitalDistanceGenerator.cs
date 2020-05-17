using TravellerUtils.Libraries.Common.Constants;
using TravellerUtils.Libraries.Common.Enums;
using TravellerUtils.Libraries.Common.Helpers;
using TravellerUtils.Libraries.Common.Interfaces;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Generators.SystemBodyGenerator
{
    public static class CompanionStarOrbitalDistanceGenerator
    {
        public static Distance Generate(IStar primaryStar, IOrbitingBody companionStar, short orbitNumberToGenerate)
        {
            if (companionStar.OrbitNumber >= 99)
            {
                return OrbitRangeGenerator.Generate(orbitNumberToGenerate);
            }

            IOrbitingBody innerObject = primaryStar.InnerOrbitingBody(companionStar.OrbitNumber);
            IOrbitingBody outerObject = primaryStar.OuterOrbitingBody(companionStar.OrbitNumber);

            Distance min = new Distance(0.1, DistanceUnits.AstronomicalUnit);
            Distance max;

            Distance maxPrimary = companionStar.OrbitalDistance / 4;

            if (innerObject == null
                && outerObject == null)
            {
                max = maxPrimary;
            }
            else if (innerObject == null)
            {
                Distance maxOuter = (outerObject.OrbitalDistance - companionStar.OrbitalDistance) / 4;

                if (maxOuter > maxPrimary)
                {
                    max = maxPrimary;
                }
                else
                {
                    max = maxOuter;
                }
            }
            else if (outerObject == null)
            {
                max = (companionStar.OrbitalDistance - innerObject.OrbitalDistance) / 4;
            }
            else
            {
                Distance maxInner = (companionStar.OrbitalDistance - innerObject.OrbitalDistance) / 4;
                Distance maxOuter = (outerObject.OrbitalDistance - companionStar.OrbitalDistance) / 4;

                if (maxInner > maxOuter)
                {
                    max = maxOuter;
                }
                else
                {
                    max = maxInner;
                }
            }

            Distance orbitalStep = (max - min) / SystemConstants.MaxOrbits;
            Distance variation = orbitalStep * .4; //So outer can't hit inner

            Distance baseOrbit = orbitalStep * orbitNumberToGenerate;

            return PerturbHelper.Change(baseOrbit - variation, baseOrbit + variation);
        }
    }
}
