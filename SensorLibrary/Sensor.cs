using System.Runtime.InteropServices;

namespace SensorLib;

public class Sensor
{
    private double _minTemp;
    private double _maxTemp;
    private TempRange _range;

    private int _step, _maxSteps;
    private bool _rising;

    public double currentTemp;

    /// <summary>
    /// A generic Sensor. Fluctuates between <paramref name="minTemp"/> and <paramref name="maxTemp"/> (inclusive) within a certain number of <paramref name="stepsPerCycle"/>.
    /// </summary>
    /// <param name="minTemp">The lowest temperature allowed (can be negative)</param>
    /// <param name="maxTemp">The highest temperature allowed (can be negative, must be higher than minTemp)</param>
    /// <param name="stepsPerCycle">The number of steps required to go from <paramref name="minTemp"/> to <paramref name="maxTemp"/>. Defaults to 100.</param>
    public Sensor(double minTemp, double maxTemp, int stepsPerCycle = 100)
    {
        _minTemp = minTemp;
        _maxTemp = maxTemp;
        _step = 0;
        _maxSteps = stepsPerCycle;
        _rising = true;
        currentTemp = minTemp;
        _range = new TempRange("Custom", minTemp, maxTemp);
    }

    /// <summary>
    /// A Sensor that uses a specific temperature range.
    /// </summary>
    /// <param name="range">The <see cref="TempRange"/> that determines the min and max temperatures.</param>
    /// <param name="stepsPerCycle">The number of steps required to go from min to max. Defaults to 100.</param>
    public Sensor(TempRange range, int stepsPerCycle = 100) : this(range.Min, range.Max, stepsPerCycle)
    {
        _range = range;
    }
}
