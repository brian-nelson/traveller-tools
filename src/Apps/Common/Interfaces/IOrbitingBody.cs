using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Interfaces
{
    public interface IOrbitingBody : ISystemBody
    {
        short OrbitNumber { get; set; }

        double OrbitEccentricity { get; set; }

        Distance OrbitalDistance { get; set; }

        double OrbitalPeriod { get; set; }

        double RotationPeriod { get; set; }

        double AxialTilt { get; set; }

        short AxialTiltEffect { get; set; }
    }
}
