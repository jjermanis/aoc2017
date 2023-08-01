using System.Text;

namespace AoC2017;

public class Day19 : DayBase, IDay
{
    private readonly List<(int dx, int dy)> DELTAS = new List<(int dx, int dy)>()
    {
        (0, 1), (1, 0), (0, -1), (-1, 0)
    };

    private readonly int _startX;
    private readonly IDictionary<(int, int), char> _network;
    private bool _isCalculated = false;
    private string _letterOrder = "";
    private int _stepCount;

    public Day19(string filename)
    { 
        var lines = TextFileStringList(filename);
        _startX = lines[0].IndexOf('|');
        _network = new Dictionary<(int, int), char>();
        for (var y = 0; y < lines.Count; y++)
            for (var x = 0; x < lines[y].Length; x++)
                if (lines[y][x] != ' ')
                    _network[(x,y)] = lines[y][x];
    }

    public Day19() : this("Day19.txt")
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(PathLetters)}: {PathLetters()}");
        Console.WriteLine($"{nameof(PathStepCount)}: {PathStepCount()}");
    }

    /// <summary>
    /// Day 19, Part 1
    /// </summary>
    /// <returns>The letters on the path, in order.</returns>    
    public string PathLetters()
    {
        if (!_isCalculated)
            CalculateProblems();
        return _letterOrder;
    }

    /// <summary>
    /// Day 19, Part 2
    /// </summary>
    /// <returns>The number of steps on the path.</returns>    
    public int PathStepCount()
    {
        if (!_isCalculated)
            CalculateProblems();
        return _stepCount;
    }

    private void CalculateProblems()
    {
        var result = new StringBuilder();
        var (x, y) = (_startX, 0);
        var deltaIndex = 0;
        var stepCount = 1;
        while (true)
        {
            var next = (x + DELTAS[deltaIndex].dx, y + DELTAS[deltaIndex].dy);
            if (_network.ContainsKey(next))
            {
                (x, y) = next;
                stepCount++;
                var content = _network[next];
                if (content >= 'A' && content <= 'Z')
                    result.Append(content);
                else if (content == '+')
                {
                    var leftIndex = (deltaIndex + 1) % 4;
                    if (_network.ContainsKey((x + DELTAS[leftIndex].dx, y + DELTAS[leftIndex].dy)))
                        deltaIndex = leftIndex;
                    else
                        deltaIndex = (deltaIndex + 3) % 4;
                }
            }
            else
            {
                _isCalculated = true;
                _letterOrder = result.ToString();
                _stepCount = stepCount;
                return;
            }
        }
    }
}