using System.Collections.Generic;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Interfaces
{
    public interface ISystemBody
    {
        short Size { get; set; }
        string Density { get; set; }
        Mass Mass { get; set; }
        Distance Diameter { get; set; }

        Dictionary<short, IOrbitingBody> OrbitingBodies { get; set; }
    }
}
