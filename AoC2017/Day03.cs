namespace AoC2017;

public class Day03 : DayBase, IDay
{
    private readonly int _targetId;

    public Day03(string filename)
        => _targetId = NumberFile(filename);

    public Day03() : this("Day03.txt")
    {
    }

    public Day03(int targetId)
        => _targetId = targetId;


    public void Do()
    {
        Console.WriteLine($"{nameof(DistanceByCount)}: {DistanceByCount()}");
        Console.WriteLine($"{nameof(NeighborSumLargerThanInput)}: {NeighborSumLargerThanInput()}");
    }

    /// <summary>
    /// Day 3, Part 1.
    /// </summary>
    /// <returns> 
    /// The number of steps required to carry the data from the target ID. IDs
    /// proceed in a spiral from the center. Step count is akin to Manhattan distance.
    /// </returns>
    public int DistanceByCount()
    {
        var loc = SquaresInOrder().ElementAt(_targetId - 1);
        return Math.Abs(loc.x) + Math.Abs(loc.y);
    }

    /// <summary>
    /// Day 3, Part 2.
    /// </summary>
    /// <returns>
    /// The first cell with a sum of all neighbors exceeding the input value. The neighbor sums
    /// are calculated in the same order as in Day 3 Part 1.
    /// </returns>
    public int NeighborSumLargerThanInput()
    {
        var values = new Dictionary<(int x, int y), int>();
        values[(0, 0)] = 1;
        foreach (var square in SquaresInOrder())
        {
            var currVal = NeighborSum(square, values);
            if (currVal > _targetId)
                return currVal;
            values[square] = currVal;
        }
        throw new Exception("Logical error - SquaresInOrder should never end");
    }

    /// <summary>
    /// An in-order collection of the squares on the grid. The pattern starts in the center
    /// and spirals outward.
    /// </summary>
    /// <returns>A collection of the xy-coords of each square, in order.</returns>
    private IEnumerable<(int x, int y)> SquaresInOrder()
    {
        int dist = 0;
        int currX = 0;
        int currY = 0;
        yield return (currX, currY);
        while (true)
        {
            // Move right, then up, then left, then down, then... repeat
            dist++;
            for (int i = 0; i < dist; i++)
                yield return (++currX, currY);
            for (int i = 0; i < dist; i++)
                yield return (currX, ++currY);
            dist++;
            for (int i = 0; i < dist; i++)
                yield return (--currX, currY);
            for (int i = 0; i < dist; i++)
                yield return (currX, --currY);
        }
    }

    private static int NeighborSum(
        (int x, int y) p, 
        Dictionary<(int x, int y), int> values)
    {
        int result = 0;
        // Note: you never want to count for dx==0 && dy==0. But due to the logic,
        // that'll never be in values.
        for (int dx = -1; dx <= 1; dx++)
            for (int dy = -1; dy <= 1; dy++)
                if (values.ContainsKey((p.x + dx, p.y + dy)))
                    result += values[(p.x + dx, p.y + dy)];
        return result;
    }
}