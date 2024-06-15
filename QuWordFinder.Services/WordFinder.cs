using System.Collections.Concurrent;

namespace QuWordFinder.Services
{
    public class WordFinder : IWordFinder
    {
        private readonly char[][] _matrix;
        private readonly int _rows;
        private readonly int _cols;

        public WordFinder(IEnumerable<string> matrix)
        {
            if (matrix == null || !matrix.Any())
            {
                throw new ArgumentException("Matrix cannot be null or empty.");
            }

            _matrix = matrix.Select(row => row.ToCharArray()).ToArray();
            _rows = _matrix.Length;
            _cols = _matrix[0].Length;

            if (_rows > 64 || _cols > 64)
            {
                throw new ArgumentException("The matrix cannot have more than 64 rows or more than 64 columns.");
            }
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            if (wordstream == null || !wordstream.Any())
            {
                return Enumerable.Empty<string>();
            }

            var wordSet = new HashSet<string>(wordstream);
            var wordCount = new ConcurrentDictionary<string, int>();

            Parallel.ForEach(wordSet, word =>
            {
                wordCount[word] = ExistsInMatrix(word);
            });

            return wordCount.OrderByDescending(wc => wc.Value)
                            .ThenBy(wc => wc.Key)
                            .Where(wc => wc.Value > 0)
                            .Take(10)
                            .Select(wc => wc.Key);
        }

        private int ExistsInMatrix(string word)
        {
            int len = word.Length;
            int count = 0;

            Parallel.For(0, _rows, r =>
            {
                for (int c = 0; c <= _cols - len; c++)
                {
                    if (IsHorizontalMatch(r, c, word))
                    {
                        Interlocked.Increment(ref count);
                    }
                }
            });

            Parallel.For(0, _cols, c =>
            {
                for (int r = 0; r <= _rows - len; r++)
                {
                    if (IsVerticalMatch(r, c, word))
                    {
                        Interlocked.Increment(ref count);
                    }
                }
            });

            return count;
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
}