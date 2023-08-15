namespace AoC2017;

public class Day23 : DayBase, IDay
{
    // TODO: the "optimization" in the VM works for 23-2... but is still
    // slow (30 sec) and will not work in general cases. How about
    // just code the problem for 23-2 directly?

    private readonly IEnumerable<string> _lines;

    public Day23(string filename)
        => _lines = TextFileLines(filename);

    public Day23() : this("Day23.txt")
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(MulInstructionCount)}: {MulInstructionCount()}");
        Console.WriteLine($"{nameof(FinalValueInRegisterH)}: {FinalValueInRegisterH()}");
    }

    public long MulInstructionCount()
    {
        var tablet = new DuetTablet(_lines);
        tablet.RunUntiEnd(false);
        return tablet.GetMulInvokeCount();
    }

    public long FinalValueInRegisterH()
    {
        var tablet = new DuetTablet(_lines);
        tablet.SetRegister('a', 1);
        tablet.RunUntiEnd(true);
        return tablet.GetRegister('h');
    }
}