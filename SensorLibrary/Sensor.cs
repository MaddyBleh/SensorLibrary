namespace SensorLib;

public class Sensor : ISensor
{
    private double _minTemp;
    private double _maxTemp;
    public TempRange tempRange;

    public double currentTemp;

    /// <summary>
    /// A generic Sensor. Fluctuates between <paramref name="minTemp"/> and <paramref name="maxTemp"/> (inclusive) within a certain number of <paramref name="stepsPerCycle"/>.
    /// </summary>
    /// <param name="minTemp">The lowest temperature allowed (can be negative)</param>
    /// <param name="maxTemp">The highest temperature allowed (can be negative, must be higher than minTemp)</param>
    public Sensor(double minTemp, double maxTemp, int stepsPerCycle = 100)
    {
        _minTemp = minTemp;
        _maxTemp = maxTemp;
        currentTemp = minTemp;
        tempRange = new TempRange("Custom", minTemp, maxTemp);
    }

    /// <summary>
    /// A Sensor that uses a specific temperature range.
    /// </summary>
    /// <param name="range">The <see cref="TempRange"/> that determines the min and max temperatures.</param>
    public Sensor(TempRange range, int stepsPerCycle = 100) : this(range.Min, range.Max, stepsPerCycle)
    {
        tempRange = range;
    }


    public double Fluctuate(
        double min, double max, Func<double, double, double, FluctuationConfig, double> fluctuation,
        FluctuationConfig config)
    {
        // Call the given fluctuation graph
        currentTemp = fluctuation(currentTemp, min, max, config);
        return currentTemp;
    }
}
