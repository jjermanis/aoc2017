
namespace AoC2017;

public abstract class DayBase
{
    private const string FILE_PATH = @"..\..\..\..\AoC2017\Inputs\";

    protected IEnumerable<string> TextFileLines(string fileName)
        => File.ReadLines(FILE_PATH + fileName);

    protected IList<string> TextFileStringList(string fileName)
        => TextFileLines(fileName).ToList();

    protected IEnumerable<int> TextFileInts(string fileName)
        => TextFileLines(fileName).Select(m => int.Parse(m));

    protected IList<int> TextFileIntList(string fileName)
        => TextFileInts(fileName).ToList();

    protected IEnumerable<int> TextFileIntsSingleLine(string fileName)
        => TextFile(fileName).Split().Select(m => int.Parse(m));

    protected IEnumerable<int> TextFileIntsSingleLine(string fileName, char delimiter)
        => TextFile(fileName).Split(delimiter).Select(m => int.Parse(m));

    protected IList<int> TextFileIntListSingleLine(string fileName)
        => TextFileIntsSingleLine(fileName).ToList();

    protected IList<int> TextFileIntListSingleLine(string fileName, char delimiter)
        => TextFileIntsSingleLine(fileName, delimiter).ToList();

    protected IEnumerable<string[]> TextFileTokens(string fileName)
    => TextFileLines(fileName).Select(x => x.Split());

    protected IEnumerable<string[]> TextFileTokens(string fileName, char delimiter)
        => TextFileLines(fileName).Select(x => x.Split(delimiter));

    protected string TextFile(string fileName)
        => File.ReadAllText(FILE_PATH + fileName);

    protected int NumberFile(string fileName)
        => int.Parse(TextFile(fileName));

    protected IDictionary<(int, int), int> TextFileIntGrid(string fileName)
        => TextFileIntGrid(TextFileStringList(fileName));

    protected IDictionary<(int, int), int> TextFileIntGrid(IList<string> lines)
    {
        var result = new Dictionary<(int, int), int>();
        var lineCount = lines.Count;
        for (int a = 0; a < lineCount; a++)
        {
            var currLine = lines[a];
            var currLen = currLine.Length;
            for (int b = 0; b < currLen; b++)
            {
                result[(a, b)] = currLine[b] - '0';
            }
        }
        return result;
    }
}