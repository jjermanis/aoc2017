namespace AoC2017;

public class Day18 : DayBase, IDay
{
    private readonly IEnumerable<string> _lines;

    public Day18(string filename)
        => _lines = TextFileLines(filename);

    public Day18() : this("Day18.txt")
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(LastSoundPlayed)}: {LastSoundPlayed()}");
        Console.WriteLine($"{nameof(PlayedSoundCount)}: {PlayedSoundCount()}");
    }

    /// <summary>
    /// Day 18, Part 1
    /// </summary>
    /// <returns>Frequency of the last sound played.</returns>    
    public long LastSoundPlayed()
        => new DuetTablet(_lines).RunUntiRecovery();

    /// <summary>
    /// Day 18, Part 2
    /// </summary>
    /// <returns>The count of times the first program played a sound</returns>    
    public long PlayedSoundCount()
    {
        var prog0 = new DuetTablet(_lines);
        var prog1 = new DuetTablet(_lines);
        prog1.SetRegister('p', 1);
        prog0.Partner = prog1;
        prog1.Partner = prog0;
        var progs = new DuetTablet[] { prog0, prog1 };
        var currProg = 0;
        while (progs[currProg].CanRun())
        {
            progs[currProg].RunAsDuo();
            currProg = currProg == 0 ? 1 : 0;
        }
        return prog1.GetValuesSent();
    }
}