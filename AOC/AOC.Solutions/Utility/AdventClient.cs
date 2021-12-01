using System.Net;

namespace AOC.Solutions.Utility;

public class AdventClient
{
    private readonly HttpClient _client;

    private const string InputDir = "../../../inputs/";

    private const string SessionFile = "../../../../session.txt";

    public AdventClient()
    {
        var cookieContainer = new CookieContainer();

        var session = File.ReadAllText(SessionFile);

        cookieContainer.Add(new Uri("https://adventofcode.com/"), new Cookie("session", session));

        var clientHandler = new HttpClientHandler
        {
            CookieContainer = cookieContainer,
            UseCookies = true
        };

        _client = new HttpClient(clientHandler);
    }

    public string FetchInput(int year, int day)
    {
        var filePath = Path.Join(InputDir, $"{day}.txt");
        
        if (File.Exists(filePath))
        {
            return File.ReadAllText(filePath);
        }
        
        var input = _client.GetStringAsync($"https://adventofcode.com/{year}/day/{day}/input").Result.Trim();

        File.WriteAllText(filePath, input);

        return input;
    }
}