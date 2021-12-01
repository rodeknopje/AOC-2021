using System.Net;

namespace AOC.Solutions.Utility;

public abstract class DayBase
{
    private const int Year = 2021;
    
    private readonly AdventClient _adventClient;

    protected abstract int Day { get; }
    
    protected DayBase()
    {
        _adventClient = new AdventClient();
    }
    
    public abstract int Solve_1();
    public abstract int Solve_2();
    
    protected string GetInputRaw() => _adventClient.FetchInput(Year, Day);
    protected List<string> GetInputLines() => _adventClient.FetchInput(Year, Day).Split('\n').ToList();
    protected List<int> GetInputNumbers() => _adventClient.FetchInput(Year, Day).Split('\n').Select(x=> Convert.ToInt32(x)).ToList();
}