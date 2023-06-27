namespace AoC2017;

public class Day04 : DayBase, IDay
{
    private readonly IEnumerable<string[]> _tokenList;

    public Day04(string filename)
        => _tokenList = TextFileTokens(filename);

    public Day04() : this("Day04.txt")
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(ValidCountExactMatch)}: {ValidCountExactMatch()}");
        Console.WriteLine($"{nameof(ValidCountAnagrams)}: {ValidCountAnagrams()}");
    }

    /// <summary>
    /// Day 4, Part 1.
    /// </summary>
    /// <returns>The number of lines where there are no duplicates.</returns>
    public int ValidCountExactMatch()
        => ValidPassphraseCount(false);


    /// <summary>
    /// Day 4, Part 2.
    /// </summary>
    /// <returns>The number of lines where there are no duplicates, including anagrams.</returns>
    public int ValidCountAnagrams()
        => ValidPassphraseCount(true);

    private int ValidPassphraseCount(bool checkAnagrams)
    {
        var result = 0;
        foreach (var line in _tokenList)
            if (IsValidPassphrase(line, checkAnagrams))
                result++;
        return result;
    }

    private static bool IsValidPassphrase(string[] passPhrase, bool checkAnagrams)
    {
        var seenWords = new HashSet<string>();
        foreach (var word in passPhrase)
        {
            // When checking for anagrams, sort each word alphabetically.
            // All anagrams will match each other when this is done.
            var wordToCheck = checkAnagrams ? SortedWord(word) : word;

            if (seenWords.Contains(wordToCheck))
                return false;

            seenWords.Add(wordToCheck);
        }
        return true;
    }

    private static string SortedWord(string word)
    {
        char[] letters = word.ToCharArray();
        Array.Sort(letters);
        return new string(letters);
    }
}