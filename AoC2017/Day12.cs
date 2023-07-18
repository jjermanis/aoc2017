namespace AoC2017;

public class Day12 : DayBase, IDay
{
    private readonly IDictionary<int, List<int>> _connections;

    public Day12(string filename)
    {
        var lines = TextFileLines(filename);
        _connections = new Dictionary<int, List<int>>();
        foreach (var line in lines)
        {
            var topLevel = line.Split(" <-> ");
            var progId = int.Parse(topLevel[0]);
            var connections = topLevel[1].Split(", ").Select(int.Parse).ToList();
            _connections[progId] = connections;
        }
    }

    public Day12() : this("Day12.txt")
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(FirstProgramCount)}: {FirstProgramCount()}");
        Console.WriteLine($"{nameof(GroupCount)}: {GroupCount()}");
    }

    /// <summary>
    /// Day 12, Part 1
    /// </summary>
    /// <returns>The count of programs in the group including Program 0</returns>    
    public int FirstProgramCount()
        => GroupMembers(0).Count;

    /// <summary>
    /// Day 12, Part 2
    /// </summary>
    /// <returns>The count of programs in the group including Program 0</returns>    
    public int GroupCount()
    {
        var result = 0;
        var visited = new HashSet<int>();
        foreach (var prog in _connections.Keys)
            if (!visited.Contains(prog))
            {
                var currGroup = GroupMembers(prog);
                foreach (var visit in currGroup)
                    visited.Add(visit);
                result++;
            }
        return result;
    }

    private HashSet<int> GroupMembers(int startingPoint)
    {
        var visited = new HashSet<int>();
        var toVisit = new Queue<int>();
        toVisit.Enqueue(startingPoint);
        while (toVisit.Count > 0)
        {
            var curr = toVisit.Dequeue();
            if (!visited.Contains(curr))
            {
                visited.Add(curr);
                var currCons = _connections[curr];
                foreach (var conn in currCons)
                    toVisit.Enqueue(conn);
            }
        }
        return visited;
    }
}