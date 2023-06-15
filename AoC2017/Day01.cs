namespace AoC2017;

public class Day01 : DayBase, IDay
{
    private readonly string _line;

    public Day01(string filename)
        => _line = TextFile(filename);

    public Day01() : this("Day01.txt")
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(CaptchaSumNeighbors)}: {CaptchaSumNeighbors()}");
        Console.WriteLine($"{nameof(CaptchaSumOpposite)}: {CaptchaSumOpposite()}");
    }

    /// <summary>
    /// Day 1, Part 1.
    /// </summary>
    /// <returns>
    /// The sum of all digits that match the next digit in the list. The list is circular, 
    /// so the digit after the last digit is the first digit in the list.
    /// </returns>
    public int CaptchaSumNeighbors()
        => CaptchaSum(1);

    /// <summary>
    /// Day 1, Part 2.
    /// </summary>
    /// <returns>
    /// The sum of all digits that match the digit halfway arouund the list. The list is 
    /// circular, so the digit after the last digit is the first digit in the list.
    /// </returns>
    public int CaptchaSumOpposite()
        => CaptchaSum(_line.Length / 2);

    /// <summary>
    /// Returns the sum of all digits (in the input file) that have the same digit OFFSET
    /// digits ahead. Note: when considering "ahead", it will wrap around to start of list 
    /// once the end is reached.
    /// </summary>
    /// <param name="offset">Number of digits ahead to compare with</param>
    /// <returns>The sum of all matched digits</returns>
    private int CaptchaSum(int offset)
    {
        var result = 0;
        for (var i = 0; i < _line.Length; i++)
            if (_line[i] == _line[(i + offset) % _line.Length])
                result += _line[i] - '0';
        return result;
    }
}