namespace AoC2017;

public class Day11 : DayBase, IDay
{
    private readonly Dictionary<string, (double x, double y)> STEP_VECTORS
        = new Dictionary<string, (double, double)>()
        {
            { "n", (0, 1) },
            { "ne", (Math.Sqrt(3)/2, 0.5) },
            { "se", (Math.Sqrt(3)/2, -0.5) },
            { "s",  (0, -1) },
            { "sw", (-Math.Sqrt(3)/2, -0.5) },
            { "nw", (-Math.Sqrt(3)/2, 0.5) },
        };
    private readonly IEnumerable<string> _steps;
    private bool _isCalculated = false;
    private int _endStepCount = -1;
    private int _maxStepCount = -1;

    public Day11(string filename)
        => _steps = TextFile(filename).Split(',');

    public Day11() : this("Day11.txt")
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(EndStepCount)}: {EndStepCount()}");
        Console.WriteLine($"{nameof(MaxStepCount)}: {MaxStepCount()}");
    }

    /// <summary>
    /// Day 11, Part 1
    /// </summary>
    /// <returns>The number of steps back to the origin at the end of the path.</returns>    
    public int EndStepCount()
    {
        if (!_isCalculated)
            CalculateProblems();
        return _endStepCount;
    }

    /// <summary>
    /// Day 11, Part 2
    /// </summary>
    /// <returns>The maximum number of steps back to the origin at any point in the path.</returns>    
    public int MaxStepCount()
    {
        if (!_isCalculated)
            CalculateProblems();
        return _maxStepCount;
    }

    private void CalculateProblems()
    {
        double x = 0;
        double y = 0;
        var currStepCount = 0;
        foreach (var step in _steps)
        {
            var vec = STEP_VECTORS[step];
            x += vec.x;
            y += vec.y;

            currStepCount = StepCountToStart(x, y);
            _maxStepCount = Math.Max(_maxStepCount, currStepCount);
        }
        _endStepCount = currStepCount;
        _isCalculated = true;
    }

    private int StepCountToStart(double x, double y)
    {
        x = Math.Abs(x);
        y = Math.Abs(y);
        var xSteps = (int)(Math.Round((2 * x) / Math.Sqrt(3)));
        var yDistFromX = ((double)xSteps / 2.0);
        if (yDistFromX >= y)
            return xSteps;
        else
            return xSteps + (int)Math.Round(y - yDistFromX);
    }
}