namespace SensorLib.Fluctuations;

public class TempFluctuations
{
    private int _step = 0;
    private int _maxSteps = 100;
    private bool _rising = true;

    public double Parabola(double current, double min, double max)
    {
        // Keep step between the range of [-1, 1]
        double x = _step / (double)_maxSteps * 2 - 1; // x between [-1, 1]

        // Parabola function, scaled to [min, max]
        double parabola = -(x * x) + 1;
        current = min + parabola * (max - min);

        // Increment or decrement step depending on direction
        if (_rising)
            _step++;
        else
            _step--;

        // Flip direction at the ends
        if (_step >= _maxSteps)
        {
            _rising = false;
            _step = _maxSteps;
        }
        else if (_step <= 0)
        {
            _rising = true;
            _step = 0;
        }

        return Math.Round(current, 3, MidpointRounding.AwayFromZero);
    }
}
