namespace AoC2017;

public class Day21 : DayBase, IDay
{
    private readonly IDictionary<string, List<string>> _patternMap;

    private readonly List<string> START = new List<string>() 
    { 
        ".#.", 
        "..#", 
        "###"
    };

    public Day21(string filename)
    {
        var lines = TextFileLines(filename);
        _patternMap = new Dictionary<string, List<string>>();
        foreach (var line in lines)
        {
            var sections = line.Split(" => ");
            var outputPattern = sections[1].Split('/').ToList();
            foreach (var inputPattern in VariantPatterns(sections[0]))
                _patternMap[inputPattern] = outputPattern;
        }
    }

    public Day21() : this("Day21.txt")
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(Part1)}: {Part1()}");
        Console.WriteLine($"{nameof(Part2)}: {Part2()}");
    }

    /// <summary>
    /// Day 21, Part 1
    /// </summary>
    /// <returns>Pixels after 5 iteratons</returns>    
    public int Part1()
        => OnPixelCount(5);

    /// <summary>
    /// Day 21, Part 2
    /// </summary>
    /// <returns>Pixels after 18 iteratons</returns>    
    public int Part2()
        => OnPixelCount(18);

    public int OnPixelCount(int iterations)
    {
        var curr = START;
        for (var i = 0; i < iterations; i++)
        {
            int currFactor = (curr.Count % 2 == 0) ? 2 : 3;
            var nextSize = curr.Count * (currFactor + 1) / currFactor;
            var next = Enumerable.Repeat(string.Empty, nextSize).ToList();
            var outY = 0;
            for (var y = 0; y < curr.Count; y += currFactor)
            {
                for (var x = 0; x < curr.Count; x += currFactor)
                {
                    var inKey = "";
                    for (var sy = 0; sy < currFactor; sy++)
                        inKey += curr[y + sy][x..(x + currFactor)] + '/';
                    inKey = inKey[0..^1];
                    var outLines = _patternMap[inKey];
                    for (var sy = 0; sy < outLines.Count; sy++)
                        next[outY + sy] += outLines[sy];
                }
                outY += currFactor + 1;
            }
            curr = next;

        }
        return curr.Sum(s => s.Count(c => c == '#'));
    }

    private IEnumerable<string> VariantPatterns(string input)
    {
        var inLines = input.Split('/');
        var curr = inLines;
        for (var i = 0; i < 4; i++)
        {
            foreach (var pattern in FlippedPatterns(curr))
                yield return pattern;
            curr = RotatePattern(curr);
        }
    }

    private IEnumerable<string> FlippedPatterns(string[] inLines)
    {
        var revLines = new string[inLines.Length];
        for (int i = 0; i < revLines.Length; i++)
            revLines[i] = new string(inLines[i].ToCharArray().Reverse().ToArray());
        yield return String.Join("/", inLines);
        yield return String.Join("/", revLines);
        yield return String.Join("/", inLines.Reverse());
        yield return String.Join("/", revLines.Reverse());
    }

    private string[] RotatePattern(string[] inLines)
    {
        var len = inLines.Length;
        var grid = new char[len, len];
        for (var x=0; x< len; x++)
            for (var y=0; y< len; y++)
            {
                grid[x, y] = inLines[x][len - y - 1];
            }
        var result = new string[len];
        for (var x = 0; x < len; x++)
            for (var y = 0; y < len; y++)
            {
                result[y] += grid[x, y];
            }
        return result;
    }
}