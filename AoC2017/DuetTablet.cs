namespace AoC2017;

internal class DuetTablet
{
    internal enum Operator
    {
        Snd,
        Set,
        Add,
        Mul,
        Mod,
        Rcv,
        Jgz
    };

    internal interface IInstruction
    {
        Operator Operator { get; }
        long? Execute(Dictionary<char, long> registers);
    }

    internal class SndVal : IInstruction
    {
        private readonly int _valueSrc;
        private readonly DuetTablet _tablet;

        public SndVal(int valueSrc, DuetTablet tablet)
        {
            _valueSrc = valueSrc;
            _tablet = tablet;
        }

        public override string ToString() => $"snd {_valueSrc}";

        public Operator Operator => Operator.Snd;

        public long? Execute(Dictionary<char, long> registers)
        {
            _tablet.LastNote = _valueSrc;
            _tablet._valuesSent++;
            if (_tablet.Partner != null)
                _tablet.Partner.AddToQueue(_tablet.LastNote);

            return null;
        }
    }

    internal class SndReg : IInstruction
    {
        private readonly char _registerSrc;
        private readonly DuetTablet _tablet;

        public SndReg(char registerSrc, DuetTablet tablet)
        {
            _registerSrc = registerSrc;
            _tablet = tablet;
        }

        public override string ToString() => $"snd {_registerSrc}";

        public Operator Operator => Operator.Snd;

        public long? Execute(Dictionary<char, long> registers)
        {
            _tablet.LastNote = registers[_registerSrc];
            _tablet._valuesSent++;
            if (_tablet.Partner != null)
                _tablet.Partner.AddToQueue(_tablet.LastNote);

            return null;
        }
    }

    internal class SetVal : IInstruction
    {
        private readonly char _registerDest;
        private readonly int _valueSrc;

        public SetVal(char registerDest, int valueSrc)
        {
            _registerDest = registerDest;
            _valueSrc = valueSrc;
        }

        public override string ToString()
            => $"set {_registerDest} {_valueSrc}";

        public Operator Operator => Operator.Set;

        public long? Execute(Dictionary<char, long> registers)
        {
            registers[_registerDest] = _valueSrc;
            return null;
        }
    }

    internal class SetReg : IInstruction
    {
        private readonly char _registerDest;
        private readonly char _registerSrc;

        public SetReg(char registerDest, char registerSrc)
        {
            _registerDest = registerDest;
            _registerSrc = registerSrc;
        }

        public override string ToString()
            => $"set {_registerDest} {_registerSrc}";

        public Operator Operator => Operator.Set;

        public long? Execute(Dictionary<char, long> registers)
        {
            registers[_registerDest] = registers[_registerSrc];
            return null;
        }
    }

    internal class AddVal : IInstruction
    {
        private readonly char _registerDest;
        private readonly int _valueSrc;

        public AddVal(char registerDest, int valueSrc)
        {
            _registerDest = registerDest;
            _valueSrc = valueSrc;
        }

        public override string ToString()
            => $"add {_registerDest} {_valueSrc}";

        public Operator Operator => Operator.Add;

        public long? Execute(Dictionary<char, long> registers)
        {
            registers[_registerDest] += _valueSrc;
            return null;
        }
    }

    internal class AddReg : IInstruction
    {
        private readonly char _registerDest;
        private readonly char _registerSrc;

        public AddReg(char registerDest, char registerSrc)
        {
            _registerDest = registerDest;
            _registerSrc = registerSrc;
        }

        public override string ToString()
            => $"add {_registerDest} {_registerSrc}";

        public Operator Operator => Operator.Add;

        public long? Execute(Dictionary<char, long> registers)
        {
            registers[_registerDest] += registers[_registerSrc];
            return null;
        }
    }

    internal class MulVal : IInstruction
    {
        private readonly char _registerDest;
        private readonly int _valueSrc;

        public MulVal(char registerDest, int valueSrc)
        {
            _registerDest = registerDest;
            _valueSrc = valueSrc;
        }

        public override string ToString()
            => $"mul {_registerDest} {_valueSrc}";

        public Operator Operator => Operator.Mul;

        public long? Execute(Dictionary<char, long> registers)
        {
            registers[_registerDest] *= _valueSrc;
            return null;
        }

    }

    internal class MulReg : IInstruction
    {
        private readonly char _registerDest;
        private readonly char _registerSrc;

        public MulReg(char registerDest, char registerSrc)
        {
            _registerDest = registerDest;
            _registerSrc = registerSrc;
        }

        public override string ToString()
            => $"mul {_registerDest} {_registerSrc}";

        public Operator Operator => Operator.Mul;

        public long? Execute(Dictionary<char, long> registers)
        {
            registers[_registerDest] *= registers[_registerSrc];
            return null;
        }

    }

    internal class ModVal : IInstruction
    {
        private readonly char _registerDest;
        private readonly int _valueSrc;

        public ModVal(char registerDest, int valueSrc)
        {
            _registerDest = registerDest;
            _valueSrc = valueSrc;
        }

        public override string ToString()
            => $"mod {_registerDest} {_valueSrc}";

        public Operator Operator => Operator.Mod;

        public long? Execute(Dictionary<char, long> registers)
        {
            registers[_registerDest] %= _valueSrc;
            return null;
        }
    }

    internal class ModReg : IInstruction
    {
        private readonly char _registerDest;
        private readonly char _registerSrc;

        public ModReg(char registerDest, char registerSrc)
        {
            _registerDest = registerDest;
            _registerSrc = registerSrc;
        }

        public override string ToString()
            => $"mod {_registerDest} {_registerSrc}";

        public Operator Operator => Operator.Mod;

        public long? Execute(Dictionary<char, long> registers)
        {
            registers[_registerDest] %= registers[_registerSrc];
            return null;
        }
    }

    internal class RcvReg : IInstruction
    {
        private readonly char _registerSrc;
        private readonly DuetTablet _tablet;

        public RcvReg(char registerSrc, DuetTablet tablet)
        {
            _registerSrc = registerSrc;
            _tablet = tablet;
        }

        public override string ToString()
            => $"rcv {_registerSrc}";

        public Operator Operator => Operator.Rcv;

        public long? Execute(Dictionary<char, long> registers)
        {
            if (_tablet.Partner == null)
                return registers[_registerSrc] != 0 ? _tablet.LastNote : null;
            else
            {
                if (_tablet._receivedQueue.Count == 0)
                    return -1;
                var curr = _tablet._receivedQueue.Dequeue();
                registers[_registerSrc] = curr;
                return null;
            }
        }
    }

    internal class JgzRegReg : IInstruction
    {
        private readonly char _registerSrc;
        private readonly char _registerDelta;

        public JgzRegReg(char registerSrc, char registerDelta)
        {
            _registerSrc = registerSrc;
            _registerDelta = registerDelta;
        }

        public override string ToString()
            => $"jgz {_registerSrc} {_registerDelta}";

        public Operator Operator => Operator.Jgz;

        public long? Execute(Dictionary<char, long> registers)
        {
            return registers[_registerSrc] > 0 ? registers[_registerDelta] : null;
        }
    }

    internal class JgzRegVal : IInstruction
    {
        private readonly char _registerSrc;
        private readonly int _valueDelta;

        public JgzRegVal(char registerSrc, int valueDelta)
        {
            _registerSrc = registerSrc;
            _valueDelta = valueDelta;
        }

        public override string ToString()
            => $"jgz {_registerSrc} {_valueDelta}";

        public Operator Operator => Operator.Jgz;

        public long? Execute(Dictionary<char, long> registers)
        {
            return registers[_registerSrc] > 0 ? _valueDelta : null;
        }
    }

    internal class JgzValVal : IInstruction
    {
        private readonly int _valueSrc;
        private readonly int _valueDelta;

        public JgzValVal(int valueSrc, int valueDelta)
        {
            _valueSrc = valueSrc;
            _valueDelta = valueDelta;
        }

        public override string ToString()
            => $"jgz {_valueSrc} {_valueDelta}";

        public Operator Operator => Operator.Jgz;

        public long? Execute(Dictionary<char, long> registers)
        {
            return _valueSrc > 0 ? _valueDelta : null;
        }
    }

    private readonly List<IInstruction> _instructions;
    private readonly Dictionary<char, long> _registers;
    private readonly Queue<long> _receivedQueue;
    private readonly int _progLen;

    private int _pc;
    private bool _isProgramEnded;
    private long _valuesSent;

    public long LastNote { get; set; }
    public DuetTablet? Partner { get; set; }

    public DuetTablet(IEnumerable<string> lines)
    {
        _instructions = new List<IInstruction>();
        foreach (var line in lines)
            _instructions.Add(CreateInstruction(line));
        _registers = new Dictionary<char, long>();
        for (var c = 'a'; c <= 'z'; c++)
            _registers[c] = 0;
        _progLen = _instructions.Count;

        _pc = 0;
        _receivedQueue = new Queue<long>();
        _isProgramEnded = false;
        _valuesSent = 0;

        LastNote = 0;
    }

    public bool CanRun()
    {
        if (_isProgramEnded)
            return false;
        if (_instructions[_pc].Operator == Operator.Rcv &&
            _receivedQueue.Count == 0)
            return false;
        return true;
    }

    public long GetValuesSent()
        => _valuesSent;

    public void SetRegister(char name, long value)
        => _registers[name] = value;

    private IInstruction CreateInstruction(string line)
    {
        var tokens = line.Split(' ');
        switch (tokens[0])
        {
            case "snd":
                {
                    var isVal = int.TryParse(tokens[1], out int value);
                    if (isVal)
                        return new SndVal(value, this);
                    else
                        return new SndReg(tokens[1][0], this);
                }
            case "set":
                {
                    var isVal = int.TryParse(tokens[2], out int value);
                    if (isVal)
                        return new SetVal(tokens[1][0], value);
                    else
                        return new SetReg(tokens[1][0], tokens[2][0]);
                }
            case "add":
                {
                    var isVal = int.TryParse(tokens[2], out int value);
                    if (isVal)
                        return new AddVal(tokens[1][0], value);
                    else
                        return new AddReg(tokens[1][0], tokens[2][0]);
                }
            case "mul":
                {
                    var isVal = int.TryParse(tokens[2], out int value);
                    if (isVal)
                        return new MulVal(tokens[1][0], value);
                    else
                        return new MulReg(tokens[1][0], tokens[2][0]);
                }
            case "mod":
                {
                    var isVal = int.TryParse(tokens[2], out int value);
                    if (isVal)
                        return new ModVal(tokens[1][0], value);
                    else
                        return new ModReg(tokens[1][0], tokens[2][0]);
                }
            case "rcv":
                return new RcvReg(tokens[1][0], this);
            case "jgz":
                {
                    var isSrcVal = int.TryParse(tokens[1], out int value1);
                    var isDstVal = int.TryParse(tokens[2], out int value2);
                    if (isSrcVal && isDstVal)
                        return new JgzValVal(value1, value2);
                    else if (isDstVal)
                        return new JgzRegVal(tokens[1][0], value2);
                    else
                        return new JgzRegReg(tokens[1][0], tokens[2][0]);
                }

            default:
                throw new Exception($"Unhandled: {line}");
        }
    }

    public void AddToQueue(long value)
        => _receivedQueue.Enqueue(value);

    public long RunUntiRecovery()
    {
        while (_pc < _progLen)
        {
            var curr = _instructions[_pc];

            var result = curr.Execute(_registers);
            if (result != null)
            {
                var val = result.Value;

                switch (curr.Operator)
                {
                    case Operator.Rcv:
                        return val;
                    case Operator.Jgz:
                        _pc += (int)(val - 1);
                        break;
                    default:
                        throw new Exception("No result expected for {curr}");
                }
            }
            _pc++;
        }
        throw new Exception("Program ended - no recovery found");
    }

    public void RunAsDuo()
    {
        while (_pc < _progLen)
        {
            var curr = _instructions[_pc];

            var result = curr.Execute(_registers);
            if (result != null)
            {
                var val = result.Value;

                switch (curr.Operator)
                {
                    case Operator.Rcv:
                        return;
                    case Operator.Jgz:
                        _pc += (int)(val - 1);
                        break;
                    default:
                        throw new Exception("No result expected for {curr}");
                }
            }
            _pc++;
        }
        _isProgramEnded = true;
    }
}
