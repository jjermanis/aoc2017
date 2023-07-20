namespace AoC2017;

public class Day14 : DayBase, IDay
{

    // TODO optimize this to generate the KnotHashes once, in the ctor.
    // It is the definite maximum of the time.
    // TODO redo Day 10 to utilize the KnotHash class.
    private readonly string _key;

    public Day14(string filename)
        => _key = TextFile(filename);

    public Day14() : this("Day14.txt")
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(SquareCount)}: {SquareCount()}");
        Console.WriteLine($"{nameof(RegionCount)}: {RegionCount()}");
    }

    /// <summary>
    /// Day 14, Part 1
    /// </summary>
    /// <returns>The count of bits marked 1 in a grid of 128 hashes.</returns>    
    public int SquareCount()
    {
        var result = 0;
        for (var x = 0; x <= 127; x++)
        {
            var curr = $"{_key}-{x}";
            var hash = new KnotHash(curr);
            var val = hash.DenseHash();
            foreach (var byteVal in val)
            {
                var currByte = byteVal;
                while (currByte > 0)
                {
                    if (currByte % 2 == 1)
                        result++;
                    currByte >>= 1;
                }
            }
        }
        return result;
    }

    /// <summary>
    /// Day 14, Part 2
    /// </summary>
    /// <returns>The count of distinct regions (of bits marked 1) on the grid.</returns>    
    public int RegionCount()
    {
        var hashList = new List<List<byte>>();
        for (var x = 0; x <= 127; x++)
        {
            var curr = $"{_key}-{x}";
            var hash = new KnotHash(curr);
            hashList.Add(hash.DenseHash());
        }
        var grid = GenerateGrid(hashList);
        return GridRegionCount(grid);
    }

    private HashSet<(int x, int y)> GenerateGrid(List<List<byte>> hashList)
    {
        var result = new HashSet<(int x, int y)>();
        for (var hashIndex = 0; hashIndex < hashList.Count; hashIndex++)
        {
            var currHash = hashList[hashIndex];
            for (var byteIndex = 0; byteIndex < currHash.Count; byteIndex++)
            {
                var currByte = currHash[byteIndex];
                var offset = 7;
                while (currByte > 0)
                {
                    if (currByte % 2 == 1)
                        result.Add((byteIndex * 8 + offset, hashIndex));
                    offset--;
                    currByte >>= 1;
                }
            }
        }
        return result;
    }

    private int GridRegionCount(HashSet<(int x, int y)> grid)
    {
        var result = 0;
        for (var y = 0; y < 128; y++)
            for (var x = 0; x < 128; x++)
            {
                if (grid.Contains((x,y)))
                {
                    RemoveRegion(grid, x, y);
                    result++;
                }
            }
        return result;
    }

    private void RemoveRegion(HashSet<(int x, int y)> grid, 
        int startX, int startY)
    {
        var squares = new Stack<(int x, int y)>();
        squares.Push((startX, startY));
        while (squares.Count > 0)
        {
            var curr = squares.Pop();
            if (grid.Contains((curr.x, curr.y)))
            {
                grid.Remove((curr.x, curr.y));
                if (grid.Contains((curr.x - 1, curr.y)))
                    squares.Push((curr.x - 1, curr.y));
                if (grid.Contains((curr.x, curr.y-1)))
                    squares.Push((curr.x, curr.y-1));
                if (grid.Contains((curr.x + 1, curr.y)))
                    squares.Push((curr.x + 1, curr.y));
                if (grid.Contains((curr.x, curr.y+1)))
                    squares.Push((curr.x, curr.y+1));
            }
        }
    }
}