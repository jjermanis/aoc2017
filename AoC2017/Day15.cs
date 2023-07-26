namespace AoC2017;

public class Day15 : DayBase, IDay
{
    private readonly int _startA;
    private readonly int _startB;

    public Day15(string filename)
    {
        var lines = TextFileLines(filename).ToList();
        _startA = int.Parse((lines[0].Split())[4]);
        _startB = int.Parse((lines[1].Split())[4]);
    }

    public Day15() : this("Day15.txt")
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(MatchingCount)}: {MatchingCount()}");
        Console.WriteLine($"{nameof(MatchingCountWithMultiples)}: {MatchingCountWithMultiples()}");
    }

    /// <summary>
    /// Day 15, Part 1
    /// </summary>
    /// <returns>In two separate cycles, the times the lower 16 bits match</returns>    
    public int MatchingCount()
    {
        long a = _startA;
        long b = _startB;
        var result = 0;
        for (int i = 0; i < 40_000_000; i++)
        {
            a *= 16807;
            a %= 2147483647;
            b *= 48271;
            b %= 2147483647;
            if ((a & 0xffffL) == (b & 0xffffL))
                result++;
        }
        return result;
    }

    /// <summary>
    /// Day 15, Part 2
    /// </summary>
    /// <returns>In two separate cycles (requiring numbers to have different multiples), the times the lower 16 bits match</returns>    
    public int MatchingCountWithMultiples()
    {
        long a = _startA;
        long b = _startB;
        var result = 0;
        for (int i = 0; i < 5_000_000; i++)
        {
            do
            {
                a *= 16807;
                a %= 2147483647;
            } while (a % 4 != 0);
            do
            {
                b *= 48271;
                b %= 2147483647;
            } while (b % 8 != 0);

            if ((a & 0xffff) == (b & 0xffff))
                result++;
        }
        return result;
    }

}