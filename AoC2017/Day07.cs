namespace AoC2017;

public class Day07 : DayBase, IDay
{
    private class Tower
    {
        public string Name { get; set; }
        public int Mass { get; set; }
        public string? Parent { get; set; }
        public List<string> Children { get; set; }

        public Tower(string name, int mass)
        {
            Name = name;
            Mass = mass;
            Parent = null;
            Children = new List<string>();
        }
    }

    private readonly Dictionary<string, Tower> _towers;

    public Day07(string filename)
    {
        _towers = new Dictionary<string, Tower>();
        var lines = TextFileLines(filename);
        foreach (var line in lines)
        {
            var tokens = line.Split();
            var name = tokens[0];
            var mass = int.Parse(tokens[1][1..^1]);
            var curr = new Tower(name, mass);
            if (tokens.Length > 2)
                foreach (var child in tokens[3..])
                {
                    var childName = child.Replace(",", null);
                    curr.Children.Add(childName);
                }
            _towers[name] = curr;
        }
        foreach (var tower in _towers.Values)
        {
            foreach (var child in tower.Children)
            {
                var childTower = _towers[child];
                childTower.Parent = tower.Name;
            }
        }
    }

    public Day07() : this("Day07.txt")
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(BottomNodeName)}: {BottomNodeName()}");
        Console.WriteLine($"{nameof(WeightToAlterTo)}: {WeightToAlterTo()}");
    }

    /// <summary>
    /// Day 7, Part 1
    /// </summary>
    /// <returns>The name of the bottom program.</returns>    
    public string BottomNodeName()
    {
        foreach (var tower in _towers.Values)
            if (tower.Parent == null)
                return tower.Name;
        throw new Exception("Bottom not found");
}

    /// <summary>
    /// Day 7, Part 2
    /// </summary>
    /// <returns>The tree is balanced, with one exception. What would that weight need to be for all to be balanced?</returns>
    public int WeightToAlterTo()
    {
        var result = 0;
        // Starting from the top, look for the one node with the different total weight. If all the weights are the 
        // same? That means the previous different weight was the place to make the change.
        var currTower = _towers[BottomNodeName()];
        while (true)
        {
            var childMasses = new List<int>();
            foreach (var child in currTower.Children)
                childMasses.Add(TotalMass(_towers[child]));
            var norm = childMasses.GroupBy(x => x).Where(x => x.Count() >= 2).Select(x => x).ToList();
            var diff = childMasses.GroupBy(x => x).Where(x => x.Count() == 1).Select(x=>x).ToList();
            if (diff.Count() == 0)
                return result;
            else
            {
                var nextIndex = childMasses.IndexOf(diff[0].Key);
                currTower = _towers[currTower.Children[nextIndex]];
                result = currTower.Mass + norm[0].Key - diff[0].Key;
            }
        }    
    }

    private int TotalMass(Tower tower)
    {
        var result = tower.Mass;
        foreach (var child in tower.Children)
            result += TotalMass(_towers[child]);
        return result;
    }
}