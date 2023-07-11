using System.Text;

namespace AoC2017;

public class Day09 : DayBase, IDay
{
    private readonly string _line;
    private bool _isCalculated = false;
    private int _score = 0;
    private int _charsRemoved;

    public Day09(string filename)
        => _line = TextFile(filename);

    public Day09() : this("Day09.txt")
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(Score)}: {Score()}");
        Console.WriteLine($"{nameof(CharsInGarbageCount)}: {CharsInGarbageCount()}");
    }

    /// <summary>
    /// Day 9, Part 1
    /// </summary>
    /// <returns>The sum of the score of the input, based on depth</returns>    
    public int Score()
    {
        if (!_isCalculated)
            CalculateProblems();
        return _score;
    }

    /// <summary>
    /// Day 9, Part 2
    /// </summary>
    /// <returns>The character count that is inside garbage</returns>    
    public int CharsInGarbageCount()
    {
        if (!_isCalculated)
            CalculateProblems();
        return _charsRemoved;
    }

    private void CalculateProblems()
    {
        _score = 0;
        foreach (var group in CleanGroups(_line))
            _score += ScoreGroup(group);

        _isCalculated = true;
    }

    private IEnumerable<string> CleanGroups(string line)
    {
        var result = new StringBuilder();

        var inGarbage = false;
        var doSkip = false;
        var depth = 0;
        _charsRemoved = 0;
        foreach (var c in line)
        {
            if (doSkip)
            {
                doSkip = false;
                continue;
            }

            if (inGarbage)
                _charsRemoved++;

            if (c == '<')
                inGarbage = true;
            else if (inGarbage)
            {
                if (c == '>')
                {
                    inGarbage = false;
                    _charsRemoved--;
                }
                else if (c == '!')
                {
                    doSkip = true;
                    _charsRemoved--;
                }
            }
            else if (c == ',' && depth == 0)
            {
                yield return result.ToString();
                result = new StringBuilder();
            }
            else
            {
                result.Append(c);
                if (c == '{')
                    depth++;
                else if (c == '}')
                    depth--;
            }
        }
        yield return result.ToString();
    }

    private static int ScoreGroup(string group)
    {
        var result = 0;
        var depth = 0;
        foreach (var c in group)
        {
            if (c == '{')
            {
                depth++;
                result += depth;
            }
            else if (c == '}')
                depth--;
        }
        return result;
    }
}