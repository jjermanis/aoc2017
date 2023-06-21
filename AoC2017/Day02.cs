namespace AoC2017;

public class Day02 : DayBase, IDay
{
    private readonly IList<List<int>> _numberLines;

    public Day02(string filename)
    {
        _numberLines = new List<List<int>>();
        var lines = TextFileLines(filename);
        foreach (var line in lines)
        {
            var curr = new List<int>();
            var nums = line.Split();
            foreach (var num in nums)
                curr.Add(int.Parse(num));
            _numberLines.Add(curr);
        }
    }

    public Day02() : this("Day02.txt")
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(SumOfBiggestDifferences)}: {SumOfBiggestDifferences()}");
        Console.WriteLine($"{nameof(SumOfEvenlyDivisibleNumbers)}: {SumOfEvenlyDivisibleNumbers()}");
    }

    /// <summary>
    /// Day 2, Part 1.
    /// </summary>
    /// <returns>
    /// The checksum for the spreadsheet in your puzzle input. The sum of the differences
    /// on each line, between the largest value and the smallest value.
    /// </returns>
    public int SumOfBiggestDifferences()
        => _numberLines.Sum(ExtremeDifference);

    /// <summary>
    /// Day 2, Part 2.
    /// </summary>
    /// <returns>
    /// The sum of each row's result. Each row's result is the quotient on that line, 
    /// between the only evenly divisible values.
    /// </returns>
    public int SumOfEvenlyDivisibleNumbers()
        => _numberLines.Sum(EvenDivision);

    private int ExtremeDifference(List<int> numbers)
        => numbers.Max() - numbers.Min();

    private static int EvenDivision(List<int> numbers)
    {
        for (var a = 0; a < numbers.Count; a++)
            for (var b = 0; b < numbers.Count; b++)
                if (a != b)
                {
                    var aVal = numbers[a];
                    var bVal = numbers[b];
                    if (aVal % bVal == 0)
                        return aVal / bVal;
                }
        throw new Exception("No even division found");
    }
}