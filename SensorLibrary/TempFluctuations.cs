namespace SensorLib.Fluctuations;

public class TempFluctuations
{
    private double _step = 0;
    private bool _rising = true;

    public double Parabola(double current, double min, double max, FluctuationConfig config)
    {
        // Keep step between the range of [-1, 1]
        double x = _step / (double)config.MaxSteps * 2 - 1; // x between [-1, 1]

        // Parabola function, scaled to [min, max]
        double parabola = -(x * x) + 1;
        current = min + parabola * (max - min);

        // Increment or decrement step depending on direction
        if (_rising)
            _step += config.Smoothness;
        //_step += 0.25; // Smooth
        else
            _step--;
        //_step -= 0.25; // Smooth

        // Flip direction at the ends
        if (_step >= config.MaxSteps)
        {
            _rising = false;
            _step = config.MaxSteps;
        }
        else if (_step <= 0)
        {
            _rising = true;
            _step = 0;
        }

        return Math.Round(current, MidpointRounding.AwayFromZero);
    }
}
