namespace QuWordFinder.Services;

public class WordFinder : IWordFinder
{
    private readonly char[][] _matrix;
    private readonly int _rows;
    private readonly int _cols;

    public WordFinder(IEnumerable<string> matrix)
    {
        if (matrix == null || !matrix.Any())
        {
            throw new ArgumentException("Matrix cannot be null or empty");
        }

        _matrix = matrix.Select(row => row.ToCharArray()).ToArray();
        _rows = _matrix.Length;
        _cols = _matrix[0].Length;
    }

    public IEnumerable<string> Find(IEnumerable<string> wordstream)
    {
        if (wordstream == null || !wordstream.Any())
        {
            return [];
        }

        var wordSet = new HashSet<string>(wordstream);
        var wordCount = new Dictionary<string, int>();

        foreach (var word in wordSet)
        {
            if (ExistsInMatrix(word))
            {
                if (wordCount.TryGetValue(word, out int value))
                {
                    wordCount[word] = ++value;
                }
                else
                {
                    wordCount[word] = 1;
                }
            }
        }

        return wordCount.OrderByDescending(wc => wc.Value)
                        .ThenBy(wc => wc.Key)
                        .Take(10)
                        .Select(wc => wc.Key);
    }

    private bool ExistsInMatrix(string word)
    {
        int len = word.Length;

        for (int r = 0; r < _rows; r++)
        {
            for (int c = 0; c <= _cols - len; c++)
            {
                if (IsHorizontalMatch(r, c, word))
                {
                    return true;
                }
            }
        }

        for (int c = 0; c < _cols; c++)
        {
            for (int r = 0; r <= _rows - len; r++)
            {
                if (IsVerticalMatch(r, c, word))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private bool IsHorizontalMatch(int r, int c, string word)
    {
        for (int i = 0; i < word.Length; i++)
        {
            if (_matrix[r][c + i] != word[i])
            {
                return false;
            }
        }
        return true;
    }

    private bool IsVerticalMatch(int r, int c, string word)
    {
        for (int i = 0; i < word.Length; i++)
        {
            if (_matrix[r + i][c] != word[i])
            {
                return false;
            }
        }
        return true;
    }
}