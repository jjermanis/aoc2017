namespace AoC2017;

public class Day24 : DayBase, IDay
{
    // TODO consolidate Part 1 and 2 into the standard Calculate pattern

    private struct Bridge
    {
        public bool[] IsComponentUsed { get; set; }
        public int CurrComponent { get; set; }
        public int Length { get; }
        public int TotalStrength { get; set; }

        public Bridge(int componentCount)
        {
            IsComponentUsed = new bool[componentCount];
            CurrComponent = 0;
            Length = 0;
            TotalStrength = 0;
        }

        public Bridge(Bridge orig)
        {
            var len = orig.IsComponentUsed.Length;
            IsComponentUsed = new bool[len];
            Array.Copy(orig.IsComponentUsed, IsComponentUsed, len);
            CurrComponent = orig.CurrComponent;
            Length = orig.Length + 1;
            TotalStrength = orig.TotalStrength;
        }
    }

    private readonly IList<(int, int)> _components;

    public Day24(string filename)
    {
        var lines = TextFileStringList(filename);
        _components = new List<(int, int)>(lines.Count);
        foreach (var line in lines)
        {
            var curr = line.Split('/');
            _components.Add((int.Parse(curr[0]), (int.Parse(curr[1]))));
        }
    }

    public Day24() : this("Day24.txt")
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(StrongestBridgeStrength)}: {StrongestBridgeStrength()}");
        Console.WriteLine($"{nameof(LongestBridgeStrength)}: {LongestBridgeStrength()}");
    }

    /// <summary>
    /// Day 24, Part 1
    /// </summary>
    /// <returns>Strength of strongest possible bridge</returns>    
    public int StrongestBridgeStrength()
    {
        var result = 0;
        var queue = new Queue<Bridge>();
        queue.Enqueue(new Bridge(_components.Count));
        while (queue.Count > 0)
        {
            var curr = queue.Dequeue();
            for (var i=0; i < _components.Count; i++)
            {
                if (!curr.IsComponentUsed[i])
                {
                    var left = _components[i].Item1;
                    var right = _components[i].Item2;
                    if (left == curr.CurrComponent ||
                        right == curr.CurrComponent)
                    {
                        var newComp = new Bridge(curr);
                        newComp.IsComponentUsed[i] = true;
                        newComp.TotalStrength += left + right;
                        newComp.CurrComponent = (curr.CurrComponent == left) ? right : left;
                        result = Math.Max(result, newComp.TotalStrength);
                        queue.Enqueue(newComp);
                    }
                }
            }
        }
        return result;
    }

    /// <summary>
    /// Day 24, Part 1
    /// </summary>
    /// <returns>Strength of longest possible bridge</returns>    
    public int LongestBridgeStrength()
    {
        var maxLen = 0;
        var maxStrength = 0;
        var queue = new Queue<Bridge>();
        queue.Enqueue(new Bridge(_components.Count));
        while (queue.Count > 0)
        {
            var curr = queue.Dequeue();
            for (var i = 0; i < _components.Count; i++)
            {
                if (!curr.IsComponentUsed[i])
                {
                    var left = _components[i].Item1;
                    var right = _components[i].Item2;
                    if (left == curr.CurrComponent ||
                        right == curr.CurrComponent)
                    {
                        var newComp = new Bridge(curr);
                        newComp.IsComponentUsed[i] = true;
                        newComp.TotalStrength += left + right;
                        newComp.CurrComponent = (curr.CurrComponent == left) ? right : left;
                            
                        if (newComp.Length > maxLen)
                        {
                            maxLen = newComp.Length;
                            maxStrength = newComp.TotalStrength;
                        }
                        if (newComp.Length == maxLen)
                            maxStrength = Math.Max(maxStrength, newComp.TotalStrength);

                        queue.Enqueue(newComp);
                    }
                }
            }
        }
        return maxStrength;
    }
}