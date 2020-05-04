using System.Collections.Generic;

namespace TravellerUtils.Libraries.Common.Interfaces
{
    public interface ISystemBody
    {
        short? Orbit { get; set; }
        List<ISystemBody> OrbitingBodies { get; set; }
    }
}
