namespace AoC2017;

public class Day10 : DayBase, IDay
{
    private readonly List<int> ASCII_INPUT_END =
        new List<int>() { 17, 31, 73, 47, 23 };

    private readonly string _input;
    private int _list_length = 256;

    public Day10(string filename)
        => _input = TextFile(filename);

    public Day10() : this("Day10.txt")
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(KnottedListProduct)}: {KnottedListProduct()}");
        Console.WriteLine($"{nameof(KnotHash)}: {KnotHash()}");
    }

    /// <summary>
    /// Day 10, Part 1
    /// </summary>
    /// <returns>The product of the first two numbers in the list, after "knotting"</returns>    
    public int KnottedListProduct()
    {
        var lengths = _input.Split(',').Select(x => int.Parse(x));
        var list = CreateList();
        int curr = 0;
        int skipSize = 0;
        foreach (var len in lengths)
        {
            ReverseSegment(list, curr, len);
            curr += skipSize++;
            curr += len;
            curr %= _list_length;
        }
        return list[0] * list[1];       
    }

    /// <summary>
    /// Day 10, Part 2
    /// </summary>
    /// <returns>The Knot Hash of your puzzle input?</returns>    
    public string KnotHash()
    {
        var lengths = AsciiInput(_input);
        var list = CreateList();
        int curr = 0;
        int skipSize = 0;
        for (var c = 0; c < 64; c++)
        {
            foreach (var len in lengths)
            {
                ReverseSegment(list, curr, len);
                curr += skipSize++;
                curr += len;
                curr %= _list_length;
            }
        }
        return KnotHash(list);
    }

    private List<int> CreateList()
    {
        var result = new List<int>(_list_length);
        for (int i = 0; i < _list_length; i++)
            result.Add(i);
        return result;
    }

    private void ReverseSegment(
        List<int> list, 
        int curr, 
        int len)
    {        
        var temp = new List<int>(len);
        for (int i=0; i<len; i++)
            temp.Add(list[(curr + i) % _list_length]);
        temp.Reverse();
        for (int i = 0; i < len; i++)
            list[(curr + i) % _list_length] = temp[i];
    }

    private IList<int> AsciiInput(string line)
    {
        var result = _input.ToCharArray().Select(x => (int)x).ToList();
        foreach (var x in ASCII_INPUT_END)
            result.Add(x);
        return result;
    }

    private string KnotHash(IList<int> line)
    {
        var result = "";
        for (var s = 0; s < 255; s += 16)
        {
            var curr = 0;
            for (var x = 0; x < 16; x++)
            {
                curr ^= line[s + x];
            }
            result += curr.ToString("x2");
        }
        return result;
    }
}