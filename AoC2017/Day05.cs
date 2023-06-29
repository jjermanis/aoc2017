namespace AoC2017;

public class Day05 : DayBase, IDay
{
    private readonly IList<int> _jumpOffsets;

    public Day05(string filename)
        => _jumpOffsets = TextFileIntList(filename);

    public Day05() : this("Day05.txt")
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(StepsToExit)}: {StepsToExit()}");
        Console.WriteLine($"{nameof(StepsWithAlternation)}: {StepsWithAlternation()}");
    }

    /// <summary>
    /// Day 5, Part 1
    /// </summary>
    /// <returns>The numbers of steps to the finish, with the step count for that spot increased 
    /// upon each visit.</returns>
    public int StepsToExit()
    {
        var jumpOffsets = new List<int>(_jumpOffsets);
        var result = 0;
        var pc = 0;
        while (pc >= 0 && pc < jumpOffsets.Count)
        {
            var offset = jumpOffsets[pc];
            jumpOffsets[pc]++;
            pc += offset;
            result++;
        }
        return result;
    }

    /// <summary>
    /// Day 5, Part 2
    /// </summary>
    /// <returns>The numbers of steps to the finish, with the step count for that spot increased 
    /// upon each visit when value of spot is <3, and decreased otherwise.</returns>
    public int StepsWithAlternation()
    {
        var jumpOffsets = new List<int>(_jumpOffsets);
        var result = 0;
        var pc = 0;
        while (pc >= 0 && pc < jumpOffsets.Count)
        {
            var offset = jumpOffsets[pc];

            // Handle the special increment/decrement cases here.
            if (offset < 3)
                jumpOffsets[pc]++;
            else
                jumpOffsets[pc]--;

            pc += offset;
            result++;
        }
        return result;
    }
}