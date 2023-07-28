namespace AoC2017;

public class Day17 : DayBase, IDay
{
    private readonly int _stepsPerInc;

    public Day17(string filename)
        => _stepsPerInc = NumberFile(filename);

    public Day17() : this("Day17.txt")
    {
    }

    public Day17(int stepsPerInc)
        => _stepsPerInc = stepsPerInc; 


    public void Do()
    {
        Console.WriteLine($"{nameof(ValueAfter2017)}: {ValueAfter2017()}");
        Console.WriteLine($"{nameof(ValueAfter0)}: {ValueAfter0()}");
    }

    /// <summary>
    /// Day 17, Part 1
    /// </summary>
    /// <returns>The value after 2017, after 2017 values are added</returns>    
    public int ValueAfter2017()
    {
        var currPos = 0;
        var buff = new List<int> { 0 };
        for (var i = 1; i <= 2017; i++)
        {
            currPos += _stepsPerInc;
            currPos %= buff.Count;
            buff.Insert(++currPos, i);
        }
        return buff[currPos+1];
    }

    /// <summary>
    /// Day 17, Part 2
    /// </summary>
    /// <returns>The value after 0, after 50 million values are added</returns>    
    public int ValueAfter0()
    {
        var currPos = 0;
        var result = 0;
        for (var i = 1; i <= 50_000_000; i++)
        {
            currPos += _stepsPerInc;
            currPos %= i;
            if (currPos == 0)
                result = i;
            currPos++;
        }
        return result;
    }
}