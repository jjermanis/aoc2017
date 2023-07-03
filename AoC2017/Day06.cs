using System.Text;

namespace AoC2017;

public class Day06 : DayBase, IDay
{
    private readonly IList<int> _startBanks;
    private bool _isCalculated = false;
    private int _cyclesUntilRepeat;
    private int _cycleLength;

    public Day06(string filename)
        => _startBanks = TextFileIntListSingleLine(filename);

    public Day06() : this("Day06.txt")
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(CyclesUntilDuplicate)}: {CyclesUntilDuplicate()}");
        Console.WriteLine($"{nameof(DuplicateLoopSize)}: {DuplicateLoopSize()}");
    }

    /// <summary>
    /// Day 6, Part 1
    /// </summary>
    /// <returns>The number of redistribution cycles that are completed before a configuration is 
    /// produced that has been seen before?</returns>
    public int CyclesUntilDuplicate()
    {
        if (!_isCalculated)
            CalculateProblems();
        return _cyclesUntilRepeat;
    }

    /// <summary>
    /// Day 6, Part 2
    /// </summary>
    /// <returns>The number of cycles performed before the repeated state is seen again</returns>
    public int DuplicateLoopSize()
    {
        if (!_isCalculated)
            CalculateProblems();
        return _cycleLength;
    }

    private void CalculateProblems()
    {
        var cycleCount = 0;
        var observed = new Dictionary<string, int>();
        var banks = new List<int>(_startBanks);
        while (true)
        {
            var moveIndex = MostBlocksIndex(banks);
            var blockCount = banks[moveIndex];

            banks[moveIndex] = 0;
            while (blockCount > 0)
            {
                moveIndex = (moveIndex + 1) % _startBanks.Count;
                banks[moveIndex]++;
                blockCount--;
            }

            cycleCount++;
            var observation = BanksObservation(banks);
            if (observed.ContainsKey(observation))
            {
                _isCalculated = true;
                _cyclesUntilRepeat = cycleCount;
                _cycleLength = cycleCount - observed[observation];
                return;
            }
            observed[observation] = cycleCount;
        }
    }

    private int MostBlocksIndex(List<int> banks)
    {
        var largestSize = -1;
        var largestIndex = -1;
        for (var i = 0; i < banks.Count; i++)
            if (banks[i] > largestSize)
            {
                largestSize = banks[i];
                largestIndex = i;
            }
        return largestIndex;
    }

    private string BanksObservation(List<int> banks)
        => String.Join(',', banks);
}