namespace AoC2017;

public class Day25 : DayBase, IDay
{
    // TODO actually parse the input file

    internal struct Instruction
    {
        public readonly int Write;
        public readonly int Move;
        public readonly char State;

        public Instruction(int write, int move, char state)
        {
            Write = write;
            Move = move;
            State = state;
        }
    }

    private readonly IDictionary<(char, int), Instruction> _blueprint;

    public Day25(string filename)
    {
        // TODO actually parse the file
        _blueprint = new Dictionary<(char, int), Instruction>();
        _blueprint[('A', 0)] = new Instruction(1, 1, 'B');
        _blueprint[('A', 1)] = new Instruction(0, -1, 'B');
        _blueprint[('B', 0)] = new Instruction(1, -1, 'C');
        _blueprint[('B', 1)] = new Instruction(0, 1, 'E');
        _blueprint[('C', 0)] = new Instruction(1, 1, 'E');
        _blueprint[('C', 1)] = new Instruction(0, -1, 'D');
        _blueprint[('D', 0)] = new Instruction(1, -1, 'A');
        _blueprint[('D', 1)] = new Instruction(1, -1, 'A');
        _blueprint[('E', 0)] = new Instruction(0, 1, 'A');
        _blueprint[('E', 1)] = new Instruction(0, 1, 'F');
        _blueprint[('F', 0)] = new Instruction(1, 1, 'E');
        _blueprint[('F', 1)] = new Instruction(1, 1, 'A');
    }

    public Day25() : this("Day25.txt")
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(DiagnosticChecksum)}: {DiagnosticChecksum()}");
        // As usual, there is not a Part2 for Day 25 (and Day 25 only)
    }

    /// <summary>
    /// Day 25, Part 1
    /// </summary>
    /// <returns>Strength of strongest possible bridge</returns>    
    public int DiagnosticChecksum()
    {
        var onesTap = new HashSet<int>();
        var state = 'A';
        var loc = 0;
        for (var i = 0; i < 12861455; i++)
        {
            var val = onesTap.Contains(loc) ? 1 : 0;
            var currInst = _blueprint[(state, val)];
            if (currInst.Write == 0)
                onesTap.Remove(loc);
            else
                onesTap.Add(loc);
            loc += currInst.Move;
            state = currInst.State;
        }
        return onesTap.Count;
    }

}