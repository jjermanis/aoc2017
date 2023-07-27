namespace AoC2017;

public class Day16 : DayBase, IDay
{
    private readonly List<string> _moves;
    private readonly int _programCount;

    public Day16(string filename, int programCount)
    {
        _moves = TextFile(filename).Split(',').ToList();
        _programCount = programCount;

    }

    public Day16() : this("Day16.txt", 16)
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(PositionAfterDance)}: {PositionAfterDance()}");
        Console.WriteLine($"{nameof(PositionAfterGigaDance)}: {PositionAfterGigaDance()}");
    }

    /// <summary>
    /// Day 16, Part 1
    /// </summary>
    /// <returns>The program position after performing the dance</returns>    
    public string PositionAfterDance()
        => PositionAfterReps(1);

    /// <summary>
    /// Day 16, Part 2
    /// </summary>
    /// <returns>The program position after performing the dance 1 billion times</returns>    
    public string PositionAfterGigaDance()
    {
        // We do not want to actually run this 1B times. First we look for a recurring pattern.
        var programs = InitPrograms();
        var startKey = new String(programs);
        var count = 0;
        do
        {
            programs = Dance(programs);
            count++;
        } while (!startKey.Equals(new String(programs)));

        // Skip ahead, based on recurrances of the pattern
        var targetLoops = 1_000_000_000 / count;
        var reps = targetLoops * count;

        // Now get up to 1B reps
        while (reps != 1_000_000_000)
        {
            programs = Dance(programs);
            reps++;
        }
        return new String(programs);
    }

    public string PositionAfterReps(int repCount)
    {
        var programs = InitPrograms();
        for (var i=0; i < repCount; i++)
            programs = Dance(programs);
        return new String(programs);
    }

    private char[] Dance(char[] programs)
    {
        foreach (var move in _moves)
        {
            switch (move[0])
            {
                case 's':
                    programs = Spin(programs, int.Parse(move[1..]));
                    break;
                case 'x':
                    var nums = move[1..].Split('/');
                    programs = Exchange(
                        programs,
                        int.Parse(nums[0]), int.Parse(nums[1]));
                    break;
                case 'p':
                    programs = Partner(programs, move[1], move[3]);
                    break;
                default:
                    throw new Exception($"Unhandled dance move: {move}");
            }
        }
        return programs;
    }

    private char[] InitPrograms()
    {
        var programs = new char[_programCount];
        for (var x = 0; x < _programCount; x++)
            programs[x] = (char)('a' + x);
        return programs;
    }

    private char[] Spin(char[] programs, int count)
    {
        var result = new char[_programCount];
        var offset = _programCount - count;
        for (int x=0; x < _programCount; x++)
            result[x] = programs[(x + offset) % _programCount];
        return result;
    }

    private static char[] Exchange(char[] programs, int indexA, int indexB)
    {
        (programs[indexA], programs[indexB]) = (programs[indexB], programs[indexA]);
        return programs;
    }

    private static char[] Partner(char[] programs, char progA, char progB)
    {
        var indexA = Array.IndexOf(programs, progA);
        var indexB = Array.IndexOf(programs, progB);
        return Exchange(programs, indexA, indexB);
    }
}