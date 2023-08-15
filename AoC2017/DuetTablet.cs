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
        Jgz,
        Jnz
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

    internal class SubVal : IInstruction
    {
        private readonly char _registerDest;
        private readonly int _valueSrc;

        public SubVal(char registerDest, int valueSrc)
        {
            _registerDest = registerDest;
            _valueSrc = valueSrc;
        }

        public override string ToString()
            => $"sub {_registerDest} {_valueSrc}";

        public Operator Operator => Operator.Add;

        public long? Execute(Dictionary<char, long> registers)
        {
            registers[_registerDest] -= _valueSrc;
            return null;
        }
    }

    internal class SubReg : IInstruction
    {
        private readonly char _registerDest;
        private readonly char _registerSrc;

        public SubReg(char registerDest, char registerSrc)
        {
            _registerDest = registerDest;
            _registerSrc = registerSrc;
        }

        public override string ToString()
            => $"sub {_registerDest} {_registerSrc}";

        public Operator Operator => Operator.Add;

        public long? Execute(Dictionary<char, long> registers)
        {
            registers[_registerDest] -= registers[_registerSrc];
            return null;
        }
    }

    internal class MulVal : IInstruction
    {
        private readonly char _registerDest;
        private readonly int _valueSrc;
        private readonly DuetTablet _tablet;

        public MulVal(char registerDest, int valueSrc, DuetTablet tablet)
        {
            _registerDest = registerDest;
            _valueSrc = valueSrc;
            _tablet = tablet;
        }

        public override string ToString()
            => $"mul {_registerDest} {_valueSrc}";

        public Operator Operator => Operator.Mul;

        public long? Execute(Dictionary<char, long> registers)
        {
            registers[_registerDest] *= _valueSrc;
            _tablet._mulInvokeCount++;
            return null;
        }

    }

    internal class MulReg : IInstruction
    {
        private readonly char _registerDest;
        private readonly char _registerSrc;
        private readonly DuetTablet _tablet;

        public MulReg(char registerDest, char registerSrc, DuetTablet tablet)
        {
            _registerDest = registerDest;
            _registerSrc = registerSrc;
            _tablet = tablet;
        }

        public override string ToString()
            => $"mul {_registerDest} {_registerSrc}";

        public Operator Operator => Operator.Mul;

        public long? Execute(Dictionary<char, long> registers)
        {
            registers[_registerDest] *= registers[_registerSrc];
            _tablet._mulInvokeCount++;
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

    internal class JnzRegReg : IInstruction
    {
        private readonly char _registerSrc;
        private readonly char _registerDelta;

        public JnzRegReg(char registerSrc, char registerDelta)
        {
            _registerSrc = registerSrc;
            _registerDelta = registerDelta;
        }

        public override string ToString()
            => $"jnz {_registerSrc} {_registerDelta}";

        public Operator Operator => Operator.Jnz;

        public long? Execute(Dictionary<char, long> registers)
        {
            return registers[_registerSrc] != 0 ? registers[_registerDelta] : null;
        }
    }

    internal class JnzRegVal : IInstruction
    {
        private readonly char _registerSrc;
        private readonly int _valueDelta;

        public JnzRegVal(char registerSrc, int valueDelta)
        {
            _registerSrc = registerSrc;
            _valueDelta = valueDelta;
        }

        public override string ToString()
            => $"jnz {_registerSrc} {_valueDelta}";

        public Operator Operator => Operator.Jnz;

        public long? Execute(Dictionary<char, long> registers)
        {
            return registers[_registerSrc] != 0 ? _valueDelta : null;
        }
    }

    internal class JnzValVal : IInstruction
    {
        private readonly int _valueSrc;
        private readonly int _valueDelta;

        public JnzValVal(int valueSrc, int valueDelta)
        {
            _valueSrc = valueSrc;
            _valueDelta = valueDelta;
        }

        public override string ToString()
            => $"jnz {_valueSrc} {_valueDelta}";

        public Operator Operator => Operator.Jnz;

        public long? Execute(Dictionary<char, long> registers)
        {
            return _valueSrc != 0 ? _valueDelta : null;
        }
    }

    private readonly List<IInstruction> _instructions;
    private readonly Dictionary<char, long> _registers;
    private readonly Queue<long> _receivedQueue;
    private readonly int _progLen;

    private int _pc;
    private bool _isProgramEnded;
    private long _valuesSent;
    private long _mulInvokeCount;

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

    public long GetMulInvokeCount()
        => _mulInvokeCount;

    public long GetRegister(char name)
        => _registers[name];

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
            case "sub":
                {
                    var isVal = int.TryParse(tokens[2], out int value);
                    if (isVal)
                        return new SubVal(tokens[1][0], value);
                    else
                        return new SubReg(tokens[1][0], tokens[2][0]);
                }
            case "mul":
                {
                    var isVal = int.TryParse(tokens[2], out int value);
                    if (isVal)
                        return new MulVal(tokens[1][0], value, this);
                    else
                        return new MulReg(tokens[1][0], tokens[2][0], this);
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
            case "jnz":
                {
                    var isSrcVal = int.TryParse(tokens[1], out int value1);
                    var isDstVal = int.TryParse(tokens[2], out int value2);
                    if (isSrcVal && isDstVal)
                        return new JnzValVal(value1, value2);
                    else if (isDstVal)
                        return new JnzRegVal(tokens[1][0], value2);
                    else
                        return new JnzRegReg(tokens[1][0], tokens[2][0]);
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

    public void RunUntiEnd(bool isOpt)
    {
        while (_pc < _progLen)
        {
            var curr = _instructions[_pc];

            if (isOpt && _pc == 23)
            {
                _registers['d'] = _registers['b'];
                _registers['g'] = 0;

                if (!IsPrime(_registers['d']))
                    _registers['f'] = 0;
            }

            var result = curr.Execute(_registers);

            if (result != null)
            {
                var val = result.Value;

                switch (curr.Operator)
                {
                    case Operator.Jgz:
                    case Operator.Jnz:
                        _pc += (int)(val - 1);
                        break;
                    default:
                        throw new Exception("No result expected for {curr}");
                }
            }
            _pc++;
        }
    }

    private static bool IsPrime(long number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        var boundary = (long)Math.Floor(Math.Sqrt(number));

        for (int i = 3; i <= boundary; i += 2)
            if (number % i == 0)
                return false;

        return true;
    }
}
