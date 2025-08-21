namespace SensorLib;

public interface ISensor
{
    /// <summary>
    /// Fluctuate the <see cref="Sensor"/> value based on a <paramref name="fluctuation"/> graph.
    /// </summary>
    /// <param name="min">The lowest temperature allowed (can be negative)</param>
    /// <param name="max">The highest temperature allowed (can be negative, must be higher than minTemp)</param>
    /// <param name="fluctuation">Function to compute next tempurature</param>
    /// <returns>New sensor value</returns>
    public double Fluctuate(double min, double max, Func<double, double, double> fluctuation);
}
