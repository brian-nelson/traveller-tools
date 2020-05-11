namespace TravellerUtils.Libraries.Common.Interfaces
{
    public interface IStellarOrbitingBody : IOrbitingBody
    {
        string OrbitType { get; set; }

        string OrbitOccupiedType { get; set; }
    }
}