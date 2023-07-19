namespace AoC2017;

public class Day13 : DayBase, IDay
{
    private readonly Dictionary<int, int> _firewalls = new Dictionary<int, int>();

    public Day13(string filename)
    { 
        var lines = TextFileLines(filename);
        foreach (var line in lines)
        {
            var curr = line.Split(": ");
            _firewalls[int.Parse(curr[0])] = int.Parse(curr[1]);
        }
    }

    public Day13() : this("Day13.txt")
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(TripSeverity)}: {TripSeverity()}");
        Console.WriteLine($"{nameof(SafeDelay)}: {SafeDelay()}");
    }

    /// <summary>
    /// Day 13, Part 1
    /// </summary>
    /// <returns>The sum of severities (product of range and depth) when caught</returns>    
    public int TripSeverity()
    {
        var result = 0;
        foreach (var layer in _firewalls.Keys)
        {
            var range = _firewalls[layer];
            var tripTime = 2 * (range - 1);
            if (layer % tripTime == 0)
                result += layer * range;
        }
        return result;
    }

    /// <summary>
    /// Day 13, Part 2
    /// </summary>
    /// <returns>The time needed to wait to avoid ever being caught</returns>    
    public int SafeDelay()
    {
        var startTime = 0;
        while (true)
            if (IsSafe(++startTime))
                return startTime;
    }

    private bool IsSafe(int start)
    {
        foreach (var layer in _firewalls.Keys)
        {
            var range = _firewalls[layer];
            var tripTime = 2 * (range - 1);
            if ((layer+start) % tripTime == 0)
                return false;
        }
        return true;
    }
}