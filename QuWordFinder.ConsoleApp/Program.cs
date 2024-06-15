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
                    "1234567890123456789012345678901234567890123456789012345678901234",
                    "2twoxxxxxxxxxxxxxxxxxxxxxthreexxeightxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    "3xxxxxxxxxxonexxxxxxxxxxxfourxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    "4xxxfivexxxxxxxxxfivexxxxsevenxxxxxxxeightxxxxxxxxxxxxxxxxxninex",
                    "5xxxxxxxxxxxxxoxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxixxxx",
                    "6xxxxxxxxxxxxxnxxxxxxxxxxxxxxxthreexxxxxxxxxxxxxxxxxxxxxxxxnxxxx",
                    "7xxxxxxxxxxxxxexxxxxxxtenxxxxxxxxxxxxxxxxxxxxeightxxxxxxxxxexxxx",
                    "8xxxtwoxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    "9xxxxxxxxsixxxxxxxxxxxsixxxxxxxxxxxfourxxxxxxxxeightxxxxxxxxxxxx",
                    "0xxxxxxxxxxxxxonexxxxfivexxxxxxxxoxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    "1xxxxxxxxxxxxxxxxxxxxxxxxxxxxuxxxxxthreexxxxxxxxxxxxxxxxxxxxxxxx",
                    "2xxxxxxxxxxxxsixxxxxxxxxxxxxxxxxrxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    "3xxxxxxxxxxxxxxxxxxxxxxxxxxxxxsevenxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    "4xxxxxxxxxxxxxxxxxxxxxxxxonetxxxxxxxxxxxxxxxxxxxxeightxxxxxninex",
                    "5xxxxxxtwoxxxxxxxxxxxxxxxfivexxxxxxxxxxxxxxxxxxxxxxxxxxxxxxixxxx",
                    "6xxxxxxxxxxxxxxxsixxxxxxxxxxnxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxnxxxx",
                    "7xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxthreeelevenxxxxxxxxxxxxxexxxx",
                    "8xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxsevenxxxxxxxxxxxxxxxxxxxxxxxx",
                    "9xxxxxxxxxxxxxxxxxxonexxxxxxxxxxtxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    "0xxxxxxxxxtwoxxxxxxxxxnxxxxxxfivexxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    "1xxxxxxxxxxxxxxxxxxexxxxxeightxxnxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    "2xxxxxxxxxxxxxxxxxxsixxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    "3xxxxxxxxxxxxxxxxxtenxxxxxxtxxxxxxxxxxxxxxxxxthreexxxxxxxxxxxxxx",
                    "4xxxxxxxxxxxxxxxxxxvxxsixxxetxxxxxxxxxxxxxxxxxxxixxxxxxxxninexxx",
                    "5xxxxxxxxxxxxxxxxxxexxxxxxonexxxxxxxxxxxxxxxxxxxxgxxxxxxxixxxxxx",
                    "6xxxxxxxxxxxxtwoxxxnxxxxxxxxnxxxxxxxxxxxxxxxxxxxxhxxxxxxxnxxxxxx",
                    "7xxxxxxxxxxxxhxxxxxxxxxxxxfourxxxxxxxxxxxxxxxxxxxtxxxxxxxexxxxxx",
                    "8xxxxxxxxxxxxrxxxxxxxxxxxxixxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    "9xxxxxxxxxxxxexxxxxxxxxxxxvxxxxxxxxtxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    "0xxxxxxxxxxxxexxxxxxxxxxxxexxxxxxxxetxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    "1xsxxxxxxxxxxxxxtwoxxxxxxxxxxxxxxxonexxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    "2xixxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxnxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    "3xxxxxxxxxxxxxxxxxxxxxxxxsixxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    "4xxxxxxxxxxxxxxxxxxxxxxxxxonexxxxxxxxxxxtxxxxxxxxxxxxxxxxxxxxxxx",
                    "5xxxxxxxxxxxxxxxxxxtwoxxxxxxxxxxxxxxxsevenxxxxxxxxxxxxxxxxxxxxxx",
                    "6xxxxxxxxxxxxxxxxxxhxxxxxxxxxxfourxxxxxxnxxxxxxxxxxxxxxxxxxxxxxx",
                    "7xxxsxxxxxxxxxxxxxxrxxxxonexxxixxxxxxxxxxxsevenxxxxxxxxninexxxxx",
                    "8xxxixxxxxxxxxxxxxxexxxxnxxxxxvxxxxxxxxxxxxxxxxxxxxxxxxixxxxxxxx",
                    "9xxxxxxxxxxxxxxxxxxexonexxxxxxexxxxxxeightxxxxxxxxxxxxxnxxxxxxxx",
                    "0exxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxfourxxxxxxxxxxxxxxxxxexxxxxxxx",
                    "1ixxxxxxxxxxxxxxxxxxxxtwoxxxxxxxxxixxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    "2gxxxxsxxxxxxxxxxxxxxxxxxxxonexxxxvxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    "3hxxxxixxxxxxxxxxxxxthreexxxxxxxxxexxxxxtenxxxxxxxxxxxxxxxxxxxxx",
                    "4txxxxxxxxxxxsevenxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    "5xxxxxxxxxxxxxxxxxxxxxxxxtwoxxxxonexxxxxxxeightxxxxxxxxxxxxxxxxx",
                    "6xxxxxxxxxxxxxxxxxsevenxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    "7xxxxxxxxxxxxxxxxxxxxxxxxthreexxxxxxxxxxxxxtenxxxxxxxxxxxxxxxxxx",
                    "8xxxxxxsxxxxxxxxxxxxxxxxxxxxxxxxtxxxxxfourxxxxxxxxxxxxxxxxxxxxxx",
                    "9xxxxxxixxxxxxxxxxxxxxxxxxoxxxxxwxxxxxoxxxxxxxxxxxxxxxxxxxxxxxxx",
                    "0xxxxxxxxxxxxxxxxxxxxxxxxxnxxxxxonexxxuxxxxxxxeightxxxxxxxxxxxxx",
                    "1xxxxxxxxxxxfivexxxxxxxxxxxxxxexxxxxxxxxxxrxxxxxxxxxxxxxxxxxxxxx",
                    "2xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxthreetxxxxxtenxxxxxxxxxxxxxxx",
                    "3xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxwxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    "4exxxxxxxxxxxxxxfivexxxxxxxxxxxxxxxxxxonexxxxxxtwelexxxxxxxxxxxx",
                    "5iixxxxxxxxxxxxxxxxxfivexxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    "6ggxxxxxxxxxxxxxxxxxxxxxfivexxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    "7hxxxxxxxxxxxxxxxxxxxxxxxxxxfivexxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    "8txxxxxsxxxxxxxxxxxxxxxxxxxxxxxtwoxxxxxxxxxxthirteenxxxxxxxxxxxx",
                    "9xxxxxxixxxxxxxxxxxxxxxxxxxxxxxhxxxxxxonexxxxxxxxxxxxxxxxxxxxxxx",
                    "0xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxrxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    "1xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxexxxxxsevenxxxxxxxxxxxxxxxxxxxxxx",
                    "2xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxexxxxxxxxxxfourxxxxxxxxxxxxxxxxxx",
                    "3xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxtwoxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    "4xxxxxxxxxxonexxxxxxxxfivexxxxxxxxxxxxxxxxsevenxxxxonexxxxxxxxxx",
                ]))
            .BuildServiceProvider();

        var wordFinder = serviceProvider.GetService<IWordFinder>();

        var wordStream = new List<string>
        {
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
            "ten",
            "eleven",
            "twele",
            "thirteen",
            "fourteen",
            "fifteen",
        };

        var foundWords = wordFinder!.Find(wordStream);

        Console.WriteLine("Found words:");
        foreach (string word in foundWords)
        {
            Console.WriteLine(word);
        }
    }
}