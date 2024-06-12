using Microsoft.Extensions.DependencyInjection;
using QuWordFinder.Services;

internal class Program
{
    private static void Main()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IWordFinder, WordFinder>(provider =>
                new WordFinder(
                [
                    "chillxxxxxxxx",
                    "xxxxxxxxxxxxx",
                    "xxxxxcoldxxxt",
                    "xcxxxxxxxxxxi",
                    "coldxxxxxxxxg",
                    "xlxxxexxxxxxe",
                    "xdxcoldxxxxxr",
                    "xxxxxexxxxxxx",
                    "xxxxxpxxxxxxx",
                    "xxxxshowxxxxx",
                    "xxxxxaxxxxxxx",
                    "xxxxxnxxxxxxx",
                    "windxtxxxxxxx",
                ]))
            .BuildServiceProvider();

        var wordFinder = serviceProvider.GetService<IWordFinder>();

        var wordStream = new List<string>
        {
            "chill",
            "wind",
            "cold",
            "snow",
            "dog",
            "tiger",
            "elephant"
        };

        var foundWords = wordFinder!.Find(wordStream);

        Console.WriteLine("Found words:");
        foreach (string word in foundWords)
        {
            Console.WriteLine(word);
        }
    }
}