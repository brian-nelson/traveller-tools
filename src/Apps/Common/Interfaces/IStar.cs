namespace TravellerUtils.Libraries.Common.Interfaces
{
    public interface IStar : ISystemBody
    {
        string Classification { get; set; }
        string LuminosityClass { get; set; }
        string DecimalNotation { get; set; }
        double Luminosity { get; set; }
        short HabitableZone { get; set; }
    }
}
