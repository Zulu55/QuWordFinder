namespace QuWordFinder.Services;

public interface IWordFinder
{
    IEnumerable<string> Find(IEnumerable<string> wordstream);
}