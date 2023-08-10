namespace AoC2017;

public class Day22 : DayBase, IDay
{
    private const int CLEANED = 0;
    private const int WEAKENED = 1;
    private const int INFECTED = 2;
    private const int FLAGGED = 3;

    private readonly List<(int dx, int dy)> VECTOR = new ()
        { (0, -1), (1, 0), (0, 1), (-1, 0) };

    private readonly HashSet<(int x, int y)> _infectedNodesStart;
    private readonly (int x, int y) _middle;

    public Day22(string filename)
    { 
        var lines = TextFileLines(filename);
        _infectedNodesStart = new HashSet<(int x, int y)>();
        var y = 0;
        foreach (var line in lines)
        {
            if (_middle.x == 0)
                _middle = (line.Length / 2, line.Length / 2);

            for (var x = 0; x < line.Length; x++)
                if (line[x] == '#')
                    _infectedNodesStart.Add((x, y));
            y++;
        }
    }

    public Day22() : this("Day22.txt")
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(InfectionBurstCount)}: {InfectionBurstCount()}");
        Console.WriteLine($"{nameof(EvolvedBurstCount)}: {EvolvedBurstCount()}");
    }

    /// <summary>
    /// Day 22, Part 1
    /// </summary>
    /// <returns>Infection bursts (with simple rules) after 10,000 rounds</returns>    
    public int InfectionBurstCount()
    {
        var result = 0;
        var grid = new HashSet<(int x, int y)>(_infectedNodesStart);
        var (x, y) = _middle;
        var dir = 0;
        for (var t=0; t<10000; t++)
        {
            if (grid.Contains((x, y)))
            {
                grid.Remove((x, y));
                dir = (dir + 1) % 4;
            }
            else
            {
                grid.Add((x, y));
                dir = (dir + 3) % 4;
                result++;
            }
            x += VECTOR[dir].dx;
            y += VECTOR[dir].dy;
        }
        return result;
    }

    /// <summary>
    /// Day 22, Part 2
    /// </summary>
    /// <returns>Infection bursts (with evolved rules) after 10,000,000 rounds</returns>    
    public int EvolvedBurstCount()
    {
        var result = 0;
        var grid = new Dictionary<(int x, int y), int>();
        foreach (var node in _infectedNodesStart)
            grid[node] = INFECTED;

        var (x, y) = _middle;
        var dir = 0;
        for (var t = 0; t < 10_000_000; t++)
        {
            int currStatus;
            if (grid.ContainsKey((x, y)))
                currStatus = grid[(x, y)];
            else
                currStatus = CLEANED;
            switch (currStatus)
            {
                case CLEANED:
                    grid[(x, y)] = WEAKENED;
                    dir = (dir + 3) % 4;
                    break;
                case WEAKENED:
                    grid[(x, y)] = INFECTED;
                    result++;
                    break;
                case INFECTED:
                    grid[(x, y)] = FLAGGED;
                    dir = (dir + 1) % 4;
                    break;
                case FLAGGED:
                    grid[(x, y)] = CLEANED;
                    dir = (dir + 2) % 4;
                    break;
                default:
                    throw new Exception("Undefined status");
            }
            x += VECTOR[dir].dx;
            y += VECTOR[dir].dy;
        }
        return result;
    }
}