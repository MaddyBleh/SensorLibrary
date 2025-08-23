namespace SensorLib;

public class FluctuationConfig
{
    public string? Name { get; }
    public double Smoothness { get; }
    public int MaxSteps { get; }

    /// <summary>
    /// Configuration for how fluctuation graphs should behave.
    /// </summary>
    /// <param name="name">The name of the configuration</param>
    /// <param name="smoothness">How gradual the curve is (smaller = smoother)</param>
    /// <param name="maxSteps">How many steps to take from lowest temperature to highest temperature</param>
    public FluctuationConfig(string? name, double smoothness = 1.0, int maxSteps = 100) 
    {
        Name = name ?? "Default";
        Smoothness = smoothness;
        MaxSteps = maxSteps;
    }

    // Predefined configs
    public static readonly FluctuationConfig Default = new FluctuationConfig("Default");
    public static readonly FluctuationConfig Smooth = new FluctuationConfig("Smooth", 0.25, 200);
    public static readonly FluctuationConfig Fast = new FluctuationConfig("Fast", 2.0, 50);
}
