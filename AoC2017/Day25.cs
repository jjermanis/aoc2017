using System.Text.RegularExpressions;

namespace AoC2017;

public class Day25 : DayBase, IDay
{
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

    private readonly char _startState;
    private readonly int _totalSteps;
    private readonly IDictionary<(char, int), Instruction> _blueprint;

    public Day25(string filename)
    {
        var lines = TextFileStringList(filename);
        var startParse = Regex.Match(lines[0],
                @"Begin in state ([A-Z])");
        _startState = startParse.Groups[1].Value[0];
        var stepsParse = Regex.Match(lines[1],
                @"Perform a diagnostic checksum after (\d*) steps.");
        _totalSteps = int.Parse(stepsParse.Groups[1].Value);

        var curr = 3;
        _blueprint = new Dictionary<(char, int), Instruction>();
        while (curr < lines.Count)
        {
            var currStateParse = Regex.Match(lines[curr],
                @"In state ([A-Z]):");
            var currState = currStateParse.Groups[1].Value[0];
            AddInstruction(lines, currState, curr + 1);
            AddInstruction(lines, currState, curr + 5);
            curr += 10;
        }
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
    /// <returns>The diagnostic checksum; the number of 1 bits after executing
    /// specified instructions </returns>    
    public int DiagnosticChecksum()
    {
        var onesTap = new HashSet<int>();
        var state = _startState;
        var loc = 0;
        for (var i = 0; i < _totalSteps; i++)
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

    private void AddInstruction(
    IList<string> lines,
    char currState,
    int currLineNum)
    {
        var (ifCurrVal, instruction) = ParseInstruction(lines, currLineNum);
        _blueprint[(currState, ifCurrVal)] = instruction;
    }

    private static (int currVal, Instruction instruction) ParseInstruction(
        IList<string> lines,
        int currLineNum)
    {
        var currValParse = Regex.Match(lines[currLineNum],
            @"If the current value is (\d):");
        var currVal = int.Parse(currValParse.Groups[1].Value);
        var writeParse = Regex.Match(lines[currLineNum + 1],
            @"Write the value (\d)");
        var write = int.Parse(writeParse.Groups[1].Value);
        var moveParse = Regex.Match(lines[currLineNum + 2],
            @"Move one slot to the ([a-z]+)");
        var move = moveParse.Groups[1].Value switch
        {
            "left" => -1,
            "right" => 1,
            _ => throw new Exception(
                $"Unexpected direction: {moveParse.Groups[1].Value}")
        };
        var nextStateParse = Regex.Match(lines[currLineNum + 3],
            @"Continue with state ([A-Z])");
        var nextState = nextStateParse.Groups[1].Value[0];

        return (currVal, new Instruction(write, move, nextState));
    }
}