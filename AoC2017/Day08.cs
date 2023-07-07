namespace AoC2017;

public class Day08 : DayBase, IDay
{
    private readonly IEnumerable<string> _lines;
    private bool _isCalculated = false;
    private int _maxValueAtEnd;
    private int _maxValueEver;

    public Day08(string filename)
        => _lines = TextFileLines(filename);

    public Day08() : this("Day08.txt")
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(MaxValueAtEnd)}: {MaxValueAtEnd()}");
        Console.WriteLine($"{nameof(MaxValueEver)}: {MaxValueEver()}");
    }

    /// <summary>
    /// Day 8, Part 1
    /// </summary>
    /// <returns>The largest value in any register after completing the instructions</returns>    
    public int MaxValueAtEnd()
    {
        if (!_isCalculated)
            CalculateProblems();
        return _maxValueAtEnd;
    }

    /// <summary>
    /// Day 8, Part 2
    /// </summary>
    /// <returns>The max value in any register at any point running the instructions</returns>    
    public int MaxValueEver()
    {
        if (!_isCalculated)
            CalculateProblems();
        return _maxValueEver;
    }

    private void CalculateProblems()
    {
        var maxVal = 0;
        var registers = new Dictionary<string, int>();
        foreach (var line in _lines)
        {
            var tokens = line.Split();
            var targetReg = tokens[0];
            var delta = int.Parse(tokens[2]);
            if (tokens[1].Equals("dec"))
                delta = -delta;
            var compL = tokens[4];
            var compOp = tokens[5];
            var compR = int.Parse(tokens[6]);

            if (!registers.ContainsKey(targetReg))
                registers[targetReg] = 0;
            if (!registers.ContainsKey(compL))
                registers[compL] = 0;
            var left = registers[compL];
            var right = compR;
            var compEval = compOp switch
            {
                "==" => left == right,
                "<" => left < right,
                ">" => left > right,
                "!=" => left != right,
                "<=" => left <= right,
                ">=" => left >= right,
                _ => throw new Exception($"Unknown comp op: {compOp}")
            };
            if (compEval)
            {
                registers[targetReg] += delta;
                maxVal = Math.Max(maxVal, registers[targetReg]);
            }
        }
        _isCalculated = true;
        _maxValueAtEnd = registers.Values.Max();
        _maxValueEver = maxVal;
    }
}