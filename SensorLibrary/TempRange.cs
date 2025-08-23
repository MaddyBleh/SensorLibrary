namespace SensorLib;

public class TempRange
{
    // Requirements for TempRange
    public string? Name { get; }
    public double Min { get; }
    public double Max { get; }

    /// <summary>
    /// A range of temperatures that a <see cref="Sensor"/> is bound to (inclusive). 
    /// </summary>
    /// <param name="name">The name of the range</param>
    /// <param name="minTemp">The lowest temperature allowed (can be negative)</param>
    /// <param name="maxTemp">The highest temperature allowed (can be negative, must be higher than minTemp)</param>
    /// <remarks>
    /// The default temperature range measures from a <paramref name="minTemp"/> of 0 to a <paramref name="maxTemp"/> of 100, with the <paramref name="name"/> "Default"
    /// </remarks>
    public TempRange(string? name, double minTemp = 0.0, double maxTemp = 100.0)
    {
        Name = name ?? "Default";
        Min = minTemp;
        Max = maxTemp;
    }

    // Predefined ranges
    public static readonly TempRange Default = new TempRange("Default");
    public static readonly TempRange Cold = new TempRange("Cold", 0, 11);
    public static readonly TempRange Neutral = new TempRange("Neutral", 11, 15);
    public static readonly TempRange Warm = new TempRange("Warm", 15, 20);
    public static readonly TempRange Hot = new TempRange("Hot", 20, 30);
}
