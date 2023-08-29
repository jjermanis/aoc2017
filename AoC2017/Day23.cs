namespace AoC2017;

public class Day23 : DayBase, IDay
{
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
        /*
         This is the direct "optimized" way to run the code in the VM
         as specified... but still takes 20+ seconds. Following this
         comment is the equivalent code avoiding the intentional sub-optimal 
         code in the problem. From what I have seen... the parameters change,
         but the fundamental problem is the same for everyone.

        var tablet = new DuetTablet(_lines);
        tablet.SetRegister('a', 1);
        tablet.RunUntiEnd(true);
        return tablet.GetRegister('h');
        */

        const int LOW_VAL = 106700;
        const int HIGH_VAL = 123700;
        const int INC = 17;
        var result = 0;
        for (var x = LOW_VAL; x <= HIGH_VAL; x += INC)
            if (!IsPrime(x))
                result++;
        return result;
    }

    private static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        var boundary = (int)Math.Floor(Math.Sqrt(number));

        for (int i = 3; i <= boundary; i += 2)
            if (number % i == 0)
                return false;

        return true;
    }
}