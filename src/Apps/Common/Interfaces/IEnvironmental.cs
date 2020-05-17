using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Interfaces
{
    public interface IEnvironmental
    {
        short Atmosphere { get; set; }
        short Hydrographics { get; set; }
        double RotationPeriod { get; set; }
        double OrbitFactor { get; set; }
        short AtmosphereCode { get; set; }
        double EnergyAbsorptionFactor { get; set; }
        double GreenhouseFactor { get; set; }
        double MeanTemperature { get; set; }
        short MaxPopulation { get; set; }
        Seasons Seasons { get; set; }
    }
}